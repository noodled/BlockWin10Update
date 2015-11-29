# BlockWin10Update

#About
Blocks the Windows 10 Update icon in your traybar on Windows 8.1 and 7 computers. The update icon wont start or appear after blocking.
Sound assets provided by Valve Corperation, extracted from TF2's `.pak` files.

![alt tag](http://i.imgur.com/5jVUvMl.png)

#Downloads
Downloads are available [here](https://github.com/ElPumpo/BlockWin10Update/releases).

You can of course clone this project and build it yourself really easily as it requires no dependencies, built on VS2015. Keep in mind of the restrictions you have due to the license.

#Methods
Creates a DWORD in your registry named `DisableGWX` in `HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\GWX` with the value `1`. That's why the application require a privileged account.

#Command line arguments: (v1.1.0.0+)
`-log` logs to `Log.txt`. If `Log.txt` already exists it will rename the old log file with date and time.

`-block` blocks the update

`-unblock` unblocks the update

Blocking and unblocking via the command line is not recommended, not fully tested and no guarantee of accually working. Doing this via the command line forces a change in the registry.

#Requirements
+ .NET Framework 4.6

#Known Issues
+ Unblocking might not work. Workaround: delete  `DisableGWX` in `HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\GWX`
+ No errorlevels are being spit out when using `-block` & `-unblock` args
+ Minor errors in GUI for non-hidpi users.

#License
<a rel="license" href="http://creativecommons.org/licenses/by-nc-nd/4.0/"><img alt="Creative Commons-licens" style="border-width:0" src="https://i.creativecommons.org/l/by-nc-nd/4.0/88x31.png" /></a><br /><span xmlns:dct="http://purl.org/dc/terms/" property="dct:title">BlockWin10Update</span> by <a xmlns:cc="http://creativecommons.org/ns#" href="http://hif.ddns.net/project/hif-client" property="cc:attributionName" rel="cc:attributionURL">ElPumpo</a> is licensed under a <a rel="license" href="http://creativecommons.org/licenses/by-nc-nd/4.0/">Creative Commons Attribution-NonCommercial-NoDerivatives 4.0 license</a>.
