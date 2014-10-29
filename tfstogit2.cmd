git init
REM from the root, add and commit any new files
git add  .
git commit -a -m "initial commit after git-tf clone-1"

REM add my github remote
git remote add origin https://github.com/krtyarepo/krtyaspeeduptest.git

git pull origin master

REM send the 'master' branch to the new 'origin' remote
git push origin master

pause 