#!/bin/bash
# Usage: ./git-create-project.sh {nombre-proyecto} {repositorio-destino}
echo "*************************** Command started **********************************"

APPSTATUS=0

echo "Cloning repo at: https://github.com/IICAUTIC/IICAWebApp.git"
git clone -o base https://github.com/IICAUTIC/IICAWebApp.git "$1"

cd $1

echo "Renaming solution"

git mv IICAWebbApp.sln $1.sln

git add .

git commit -m "Renamed solution to: $1.sln"

echo "Adding origin remote: $2"

git remote add origin $2

if [ $? = 0 ] ; then
    echo "Added the repo $2"
    git push origin master
    if [ $? != 0 ] ; then
        APPSTATUS=2
        echo "Error pushing the repo to the desired remote"
    fi
else
    APPSTATUS=2
    echo "Error adding the remote, please make sure the URL is correct."
fi

if [ "$APPSTATUS" = 2 ] ; then
    cd ..
    rm -rf $1
    echo "The process finished with an error, rolling back..."
else
    echo "Process finished successfully."
fi