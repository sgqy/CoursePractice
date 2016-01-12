
#include <Uefi.h>
#include <Library/UefiLib.h>
#include <Library/UefiBootServicesTableLib.h>

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "ConwayExample.h"
#include "AllocTable.h"

EFI_CONWAY_EXAMPLE_PROTOCOL* ConwayExample;

int main(IN int argc, IN char** argv)
{
    if (argc != 3)
    {
        printf("Player <width> <height>\r\n");
        return 0;
    }

    EFI_GUID gEfiConwayExampleGUID = EFI_CONWAY_EXAMPLE_PROTOCOL_GUID;

    EFI_STATUS Status = gBS->LocateProtocol(&gEfiConwayExampleGUID, NULL, (VOID**)&ConwayExample);
    if (EFI_ERROR(Status))
    {
        Print(L"LocateProtocol %r\n", Status);
        return Status;
    }

    CONST UINT8 w = (UINT8)strtol(argv[1], 0, 10);
    CONST UINT8 h = (UINT8)strtol(argv[2], 0, 10);

    Status = ConwayExample->SetArea(ConwayExample, w, h);
    if (Status != 0)
    {
        Print(L"SetArea %r\n", Status);
        return Status;
    }

    UINT8** Table = 0;
    AllocTable(&Table, 0, w, h);

    for (int ge = 1;; ++ge)
    {
        ConwayExample->GetNext(ConwayExample, Table);

        for (int i = 0; i < h; ++i)
        {
            for (int j = 0; j < w; ++j)
            {
                printf(Table[j][i] ? "O " : "  ");
            }
            printf("\n\r");
        }

        printf("Generate %d\r\n", ge);
        fflush(stdout);

        while (1)
        {
            char cmd = (char)getchar();
            if (cmd == 'q') exit(0);
            else break;
        }
    }
    //return 0;
}
