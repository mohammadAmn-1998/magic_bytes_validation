# magic_bytes_validation

For security reasons we need to check files before we upload them and because file extension can be Renamed so we need to check Bytes of file and compare it with executable files first two bytes wich alwayes is "4D-5A" or "5A-4D" to prevent hackers from sending files with correct extension but not the expected file.

first install FluentValidation Package from nuget package  console or Run this following command in
nuget package manager console:

Install-Package FluentValidation

then use the magic bytes validation method i write in ctor of FileUploadValidator in your Validator Class. 




