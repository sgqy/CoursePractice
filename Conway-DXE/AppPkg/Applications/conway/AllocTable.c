
#include <Uefi.h> 
#include <stdlib.h>
#include <string.h>

#include "AllocTable.h"

int AllocTable(UINT8*** square, const UINT8 OldWidth, const UINT8 Width, const UINT8 Height)
{
    // clean old table
    if (*square != NULL)
    {
        for (int i = 0; i < OldWidth; ++i)
            free((*square)[i]);
        free(*square);
        *square = NULL;
    }

    // allocate new table
    *square = (UINT8**)malloc(Width * sizeof(UINT8*));
    if (*square == NULL)  goto alloc_error;
    memset(*square, 0, Width * sizeof(UINT8*));
    for (int i = 0; i < Width; ++i)
    {
        (*square)[i] = (UINT8*)malloc(Height * sizeof(UINT8));
        if ((*square)[i] == NULL) goto alloc_error;
    }
    return 0;

alloc_error:
    if (*square != NULL)
    {
        for (int i = 0; i < Width; ++i)
            if ((*square)[i] != NULL)
                free((*square)[i]);
        free(*square);
        *square = NULL;
    }
    return 1;
}
