@echo off
set /p message="Enter message: "
git add *
git commit -m "%message%"
git push