#!/bin/sh
LC_ALL=C
# Select files to format
FILES=$(git diff --cached --name-only --diff-filter=ACM "*.cs" | sed 's| |\\ |g')
[ -z "$FILES" ] && exit 0
# Format all selected files
echo "$FILES" | cat | xargs | sed -e 's/ /,/g' | xargs dotnet-format --files
# Add back the modified files to staging
echo "$FILES" | xargs git add
exit 0