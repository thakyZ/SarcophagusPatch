@echo off

powershell -NoProfile -Command "Remove-Item -Recurse -Path .\dist"
powershell -NoProfile -Command "New-Item -ItemType Directory -Path .\dist"
powershell -NoProfile -Command "New-Item -ItemType Directory -Path \".\dist\Sarcophagus Patch\""
powershell -NoProfile -Command "New-Item -ItemType Directory -Path \".\dist\Sarcophagus Patch\About\""
powershell -NoProfile -Command "Copy-Item -Recurse -Path .\About\About.xml \".\dist\Sarcophagus Patch\About\""
powershell -NoProfile -Command "Copy-Item -Recurse -Path .\About\Manifest.xml \".\dist\Sarcophagus Patch\About\""
powershell -NoProfile -Command "Copy-Item -Recurse -Path .\Assemblies \".\dist\Sarcophagus Patch\""
powershell -NoProfile -Command "Copy-Item -Recurse -Path .\Source \".\dist\Sarcophagus Patch\""
powershell -NoProfile -Command "Remove-Item -Recurse -Path \".\dist\Sarcophagus Patch\Source\obj\""
powershell -NoProfile -Command "Remove-Item -Path \".\dist\Sarcophagus Patch\Source\Sarcophagus_Patch.csproj.user\""
powershell -NoProfile -Command "Copy-Item -Recurse -Path .\LICENSE \".\dist\Sarcophagus Patch\""
powershell -NoProfile -Command "Copy-Item -Recurse -Path .\Sarcophagus_Patch.sln \".\dist\Sarcophagus Patch\""
