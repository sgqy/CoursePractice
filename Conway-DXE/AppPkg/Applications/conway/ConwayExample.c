
//#undef _DEBUG

#include <Uefi.h> 
#include <Library/UefiBootServicesTableLib.h>
#include <Library/DebugLib.h>

#include <stdlib.h>
#include <time.h>

#include "ConwayExample.h"
#include "AllocTable.h"

#define CONWAY_EXAMPLE_PRIVATE_DATA_SIGNATURE SIGNATURE_32 ('C', 'N', 'W', 'Y')

typedef struct
{
    UINTN Signature;
    EFI_CONWAY_EXAMPLE ConwayExample;
    UINT8 ucWidth;
    UINT8 ucHeight;
    UINT8** pStatus;
} CONWAY_EXAMPLE_PRIVATE_DATA;

#define CONWAY_EXAMPLE_PRIVATE_DATA_FROM_THIS(s) \
    CR(s, CONWAY_EXAMPLE_PRIVATE_DATA, ConwayExample, CONWAY_EXAMPLE_PRIVATE_DATA_SIGNATURE)

static CONWAY_EXAMPLE_PRIVATE_DATA gConwayExamplePrivate;
EFI_GUID gEfiConwayExampleGUID = EFI_CONWAY_EXAMPLE_PROTOCOL_GUID;

EFI_STATUS EFIAPI SetArea(IN EFI_CONWAY_EXAMPLE_PROTOCOL* This, IN CONST UINT8 Width, IN CONST UINT8 Height)
{
    // init function
    CONWAY_EXAMPLE_PRIVATE_DATA* Private;
    Private = CONWAY_EXAMPLE_PRIVATE_DATA_FROM_THIS(This);

    if (AllocTable(&Private->pStatus, Private->ucWidth, Width, Height) != 0)
        return RETURN_BAD_BUFFER_SIZE;

    // set new table property
    Private->ucWidth = Width;
    Private->ucHeight = Height;


    // build new table
    srand(time(0));
    for (int i = 0; i < Private->ucWidth; ++i)
        for (int j = 0; j < Private->ucHeight; ++j)
            Private->pStatus[i][j] = (UINT8)(rand() & 1);

    return EFI_SUCCESS;
}

EFI_STATUS EFIAPI GetNext(IN EFI_CONWAY_EXAMPLE_PROTOCOL* This, OUT UINT8** CONST Table)
{
    CONWAY_EXAMPLE_PRIVATE_DATA* Private;
    Private = CONWAY_EXAMPLE_PRIVATE_DATA_FROM_THIS(This);

    const int h = Private->ucHeight;
    const int w = Private->ucWidth;
    UINT8** OldTable = Private->pStatus;

    // evolve
    for (int i = 0; i < h; ++i)
        for (int j = 0; j < w; ++j)
        {
            int n = 0;
            for (int i1 = i - 1; i1 <= i + 1; ++i1)
                for (int j1 = j - 1; j1 <= j + 1; ++j1)
                    if (OldTable[(j1 + w) % w][(i1 + h) % h])
                        ++n;
            if (OldTable[j][i]) --n;
            Table[j][i] = (n == 3 || (n == 2 && OldTable[j][i]));
        }

    // update internal table
    for (int i = 0; i < h; ++i)
        for (int j = 0; j < w; ++j)
        {
            OldTable[j][i] = Table[j][i];
        }

    return EFI_SUCCESS;
}

EFI_CONWAY_EXAMPLE_PROTOCOL* EFIAPI InitConwayExamplePrivate()
{
    //EFI_STATUS Status = 0;
    CONWAY_EXAMPLE_PRIVATE_DATA* Private = &gConwayExamplePrivate;
    Private->Signature = CONWAY_EXAMPLE_PRIVATE_DATA_SIGNATURE;
    Private->ConwayExample.SetArea = SetArea;
    Private->ConwayExample.GetNext = GetNext;
    Private->pStatus = NULL;
    return &(Private->ConwayExample);
}

EFI_STATUS EFIAPI InitConwayExample(IN EFI_HANDLE ImageHandle, IN EFI_SYSTEM_TABLE* SystemTable)
{
    EFI_STATUS Status = 0;
    CONWAY_EXAMPLE_PRIVATE_DATA* Private = &gConwayExamplePrivate;
    ShellLibConstructorWorker2(NULL, NULL, NULL, NULL);
    (void)DriverInitMain(0, NULL);
    (void)InitConwayExamplePrivate();
    Status = gBS->InstallProtocolInterface(&ImageHandle, &gEfiConwayExampleGUID, EFI_NATIVE_INTERFACE, &(Private->ConwayExample));
    return Status;
}

// for link
int main(IN int ac, IN char** av){ return 0; }
