LC-verif
--------------------------------------------------------------------------------
This is a simple C# program to verify the SHA256 hashes to stuff you download
from the internet. There are many like it, but this one is mine.

How to use old CLI version (v1.0):
1. Download from releases tab
2. Add its directory to your PATH environment variable
3. Type: lc-verify <file/dir> <path of file or directory>
4. Profit???

How to use new GUI version (v2.0):
1. Download from releases tab
2. Execute
3. Type in the path to a file or directory you want the hash(es) of
4. Click verify
5. Profit???

How to build:
1. Download .NET (or use the integrated one where the powershell is too on windows)
2. Download git
3. Add the directory with the compiler to $PATH or %PATH% (depending on what your OS is)
4. Open a terminal in the directory where you cloned the code into
   (clone this repo by typing this command into a terminal window:
    git clone https://github.com/LibreCoder951/lc-verify.git)
5. Type this command: cd lc-verify
6. Then this one: csc *.cs /out:LC-verify(.exe (if you're on windows))
7. Ignore all warnings that the compiler gives you, and use the program.

I might add more hash types in the future. For now SHA256 should be enough.
