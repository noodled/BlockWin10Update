# BlockWin10Update

#About
Blocks the Windows 10 Update icon & application on Windows 8.1 and 7 computers from launching. The update icon wont ever start or appear after blocking.
Sound assets provided by Valve Corperation, extracted from Team Fortress 2 `.pak` files.

![alt tag](http://i.imgur.com/5jVUvMl.png)

#Downloads
Downloads are available [here](https://github.com/ElPumpo/BlockWin10Update/releases).

You can of course clone this project and build it yourself really easily as it requires no dependencies, built on VS2015. Keep in mind of the restrictions you have due to the license.

#Methods
Creates a DWORD in your registry named `DisableGWX` in `HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\GWX` with the value `1`. That's why the application require a privileged account.

#Command line arguments: (v1.1.0.0+)
`-log` logs to `BlockWin10Update YYYY-MM-DD.log`. If a log file with the same date already exists the logger will instead be logging to `BlockWin10Update YYYY-MM-DD HH-MM-SS.log`

`-block` blocks the update

`-unblock` unblocks the update

Blocking and unblocking via the command line is not recommended, not fully tested and no guarantee of accually working. Doing this via the command line forces a change in the registry. Note that unblocking when no key exists, the application will throw a exception.

#Requirements
+ .NET Framework 4.6

#Example scripting: (v1.1.0.2+)
The application outputs errorlevels if command line arguments are used. Here's a example if you're planning to for whatever reason.
run.bat:
```
title BlockWin10Update Example Script
:main
cls
echo 1. Block
echo 2. Unblock
echo.
set choice=
set /p choice=Choice: 
if "%choice%"=="1" (
start /wait BlockWin10Update.exe -block
goto status_%errorlevel%
)
if "%choice%"=="2" (
start /wait BlockWin10Update.exe -unblock
goto status_%errorlevel%
)
goto main

:status_0 ::successful
echo Done!
exit /b 0

:status_1 ::error adding to registry
echo An error occurred whilst trying to modify the registry.
exit /b 1

:status_2 ::other or unknown error
echo An unknown error occurred, please rerun the applcation without any command line arguments.
```

#Known Issues
+ No errorlevels are being spit out when using `-block` & `-unblock` args - solved in v1.1.0.2
+ Minor errors in GUI for non-hidpi users.

#License
Starting v1.1.0.2, I'm swtiching license to GPLv3, as CC isn't recommended for developers.

BlockWin10Update - Blocks the Windows 10 Update tray icon.
Copyright (C) 2016 Hawaii_Beach

This program Is free software: you can redistribute it And/Or modify
it under the terms Of the GNU General Public License As published by
the Free Software Foundation, either version 3 Of the License, Or
(at your option) any later version.

This program Is distributed In the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty Of
MERCHANTABILITY Or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License For more details.

You should have received a copy Of the GNU General Public License
along with this program.  If Not, see <http://www.gnu.org/licenses/>.
