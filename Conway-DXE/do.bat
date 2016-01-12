build -p AppPkg\AppPkg.dsc
copy /y "%~dp0Build\AppPkg\DEBUG_VS2013x86\IA32\ConwaySvc.efi" "%~dp0Build\NT32IA32\DEBUG_VS2013x86\IA32\ConwaySvc.efi"
copy /y "%~dp0Build\AppPkg\DEBUG_VS2013x86\IA32\Player.efi" "%~dp0Build\NT32IA32\DEBUG_VS2013x86\IA32\Player.efi"
