@echo off
setlocal enabledelayedexpansion

rem Specify the name of the branch to push to
set target_branch=main

rem Fetch the latest changes from the remote repository
git fetch

rem Get the list of commit hashes in chronological order
for /f %%A in ('git rev-list --reverse HEAD') do (
    set commit_hash=%%A
    echo Pushing commit: !commit_hash!
    
    rem Push the commit to GitHub
    git push origin +!commit_hash!:refs/heads/!target_branch!
)

endlocal
