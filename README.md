# BlockWin10Update

#About
Blocks the Windows 10 Update on Windows 8.1 and 7 computers. The update icon wont start or appear anymore.
Sound assets provided by Valve Corperation, extracted from TF2's `.pak` files.

![alt tag](http://i.imgur.com/5jVUvMl.png)

#Downloads
Downloads are available [here](https://github.com/ElPumpo/BlockWin10Update/releases).

#How?
Creates a DWORD in your registry named `DisableGWX` in `HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\GWX` with the value `1`. That's why the application require a privileged account.

#Requirements
+ .NET 4.6

#License
<a rel="license" href="http://creativecommons.org/licenses/by-nc-nd/4.0/"><img alt="Creative Commons-licens" style="border-width:0" src="https://i.creativecommons.org/l/by-nc-nd/4.0/88x31.png" /></a><br /><span xmlns:dct="http://purl.org/dc/terms/" property="dct:title">BlockWin10Update</span> by <a xmlns:cc="http://creativecommons.org/ns#" href="http://hif.ddns.net/project/hif-client" property="cc:attributionName" rel="cc:attributionURL">ElPumpo</a> is licensed under a <a rel="license" href="http://creativecommons.org/licenses/by-nc-nd/4.0/">Creative Commons Attribution-NonCommercial-NoDerivatives 4.0 license</a>.
