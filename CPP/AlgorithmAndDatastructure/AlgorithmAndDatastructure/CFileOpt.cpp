#include "CFileOpt.h"
#include <Sys/stat.h>
#include <fstream>
//#include "unistd.h"
using namespace std;
bool CFileOpt::isFileExist_ifstream(std::string path)
{
	ifstream f(path.c_str());
	return f.good();
}
bool CFileOpt::isFileExist_fopen(std::string path)
{
	/*if (FILE* file = fopen(path.c_str(), "r")) {
		fclose(file);
		return true;
	}
	else {
		return false;
	}*/
	return true;
}
bool CFileOpt::isFileExist_access(std::string path)
{
	//return (access(path.c_str(), F_OK) != -1);
	return true;
}
bool CFileOpt::isFileExist_stat(std::string path)
{
	struct stat buffer;
	return (stat(path.c_str(), &buffer) == 0);
}