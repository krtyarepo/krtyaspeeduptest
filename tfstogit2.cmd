git init
REM from the root, add and commit any new files
git add a_text_file.txt 
git commit -a -m "initial commit after git-tf clone-1"

REM add my github remote
git remote add origin https://github.com/krtyarepo/krtyaspeeduptest.git

REM send the 'master' branch to the new 'origin' remote
git push origin test

pause 