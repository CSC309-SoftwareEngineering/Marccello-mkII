@echo off
set exists=0
set curVer=
::run script to create Database
sqlcmd -S %computername%\SQLEXPRESS -E -i 001MarccelloCreate.sql

::read version number from DB_Version.txt
for %%f in (*.txt) do (
	if %%f==DB_Version.txt (
		set exists=1
		ECHO DB_Version.txt already exists
		::Read in version number from DB_Version.txt
		for /f "delims=" %%i in (DB_Version.txt) do call set curVer=%%i
	)
)
ECHO Current database version = %curVer%

::if DB_Version does not exist, create it and add 001.sql
if %exists%==0 (
	ECHO Create: DB_Version.txt
	ECHO 001.sql >> DB_Version.txt
	for /f "delims=" %%i in (DB_Version.txt) do call set curVer=%%i
)

::run all .sql files in current directory
for %%f in (*.sql) do (
	if not %%f==001MarccelloCreate.sql (
		if %%f gtr %curVer% (
			sqlcmd  -S %computername%\SQLEXPRESS -E -d Marccello -i %%f
			ECHO Added from %%f
			ECHO %%f > DB_Version.txt
		)
	)
)
pause