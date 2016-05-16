# Git notes

Force local repo to Github (paths must be set)

    git push -f origin master

Squashing

    git checkout develop
    git merge --squash feature/...
    git commit -am '#issue comment'
    git push origin develop

[Interactive rebase in SourceTree (2014)](http://blogs.atlassian.com/2014/06/interactive-rebase-sourcetree/)

[Interactive Rebasing with SourceTree, Matthew Setter](https://www.youtube.com/watch?v=mBCJCuU3p7I)