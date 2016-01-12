
#ifndef __EFI_CONWAY_EXAMPLE_PROTOCOL_H__
#define __EFI_CONWAY_EXAMPLE_PROTOCOL_H__

//#include <Uefi.h>

#define EFI_CONWAY_EXAMPLE_PROTOCOL_GUID { 0xc3794167, 0x4d22, 0x40d6, { 0x91, 0xe7, 0x9a, 0xbe, 0xd6, 0x5b, 0x18, 0x7d } }
#define CONWAY_EXAMPLE_PROTOCOL EFI_CONWAY_EXAMPLE_PROTOCOL_GUID

typedef struct _EFI_CONWAY_EXAMPLE_PROTOCOL EFI_CONWAY_EXAMPLE_PROTOCOL;
typedef EFI_CONWAY_EXAMPLE_PROTOCOL EFI_CONWAY_EXAMPLE_INTERFACE;
typedef EFI_CONWAY_EXAMPLE_PROTOCOL EFI_CONWAY_EXAMPLE;

typedef EFI_STATUS(EFIAPI* EFI_SET_AREA)(IN EFI_CONWAY_EXAMPLE_PROTOCOL* This, IN CONST UINT8 Width, IN CONST UINT8 Height);
typedef EFI_STATUS(EFIAPI* EFI_GET_NEXT)(IN EFI_CONWAY_EXAMPLE_PROTOCOL* This, OUT UINT8** CONST Table);

struct _EFI_CONWAY_EXAMPLE_PROTOCOL
{
    EFI_SET_AREA SetArea;
    EFI_GET_NEXT GetNext;
};

extern EFI_GUID gEfiConwayExampleGUID;

EFI_STATUS EFIAPI ShellLibConstructorWorker2(void* aEfiShellProtocol, void* aEfiShellParametersProtocol, void* aEfiShellEnvironment2, void* aEfiShellInterface);
INTN EFIAPI DriverInitMain(IN UINTN Argc, IN CHAR16 **Argv);

#endif