#pragma once
//#include <string.h>
#include <iostream>
class CFileOpt
{
public:
	//�ж��ļ��Ƿ����
	bool isFileExist_ifstream(std::string path);
	bool isFileExist_fopen(std::string path);
	bool isFileExist_access(std::string path);
	bool isFileExist_stat(std::string path);


};

