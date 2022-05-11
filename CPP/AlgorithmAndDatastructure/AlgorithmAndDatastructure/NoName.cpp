#include<iostream>
#include <string.h>
#include "CFileOpt.h"
#include <windows.h>

using namespace std;
template <typename T>
void Swap(T& a, T& b)
{
	T temp = a;
	a = b;
	b = temp;
}
//void Swap(int& a, int& b)
//{
//	int temp = a;
//	a = b;
//	b = temp;
//	cout << "change over..." << endl;
//}

template <class T>
class Person
{
private:
	T m_name;
public:
	Person(T name)
	{
		m_name = name;
	}
public: 
	void DisplayInfo();
};

template <class T>
void Person<T>::DisplayInfo()
{
	cout << m_name << endl;
}

int GetRFC(int a, int b)
{
	int dd ;
	if (a<b)
	{
		Swap(a, b);
	}
	dd = a % b;
	while (dd !=0)
	{
		b = a;
		a = dd;
		dd = a % b;
	}
	return b;
}
void OpenExe(string path)
{
	CFileOpt opf;
	if (!opf.isFileExist_ifstream(path))
		cout << "can not open the file " << path << endl;
	STARTUPINFO startinfo = {};
	PROCESS_INFORMATION information = {};
	BOOL bSuccess = CreateProcess(TEXT("E:\\Study\\CodeStudy\\CSharp\\SecondTest\\SecondTest\\bin\\Debug\\netcoreapp3.1\\SecondTest.exe"), NULL, NULL, NULL, false, NULL, NULL, NULL, &startinfo, &information);
	if (bSuccess)
	{
		cout << "进程ID " << information.dwProcessId << endl;

	}
	else
	{
		cout << "open the exe file error " << GetLastError() << endl;
	}
}
class A
{
	double d;
	char c;
	float b;
	int a = 10;
	char e;

public:
	A()
	{
		cout << "Base A" << endl;
	}
	~A()
	{
		cout << "Base ~A" << endl;
	}
	friend void callFun(A a);
	inline void showInfo()
	{
		cout << "goodA" << endl;
	}
};

void callFun(A a)
{
	cout << a.a << endl;
}
class B:virtual public A
{
public:
	B()
	{
		cout << "Base B" << endl;
	}
	~B()
	{
		cout << "Base ~B" << endl;
	}
	inline void showInfo()
	{
		cout << "goodB" << endl;
	}
};
class C:virtual public A
{
public:
	C()
	{
		cout << "Base C" << endl;
	}
	~C()
	{
		cout << "Base ~C" << endl;
	}
	inline void showInfo()
	{
		cout << "goodC" << endl;
	}
};
class D: public B, public C
{
public:
	D()
	{
		cout << "Base D" << endl;
	}
	~D()
	{
		cout << "Base ~D" << endl;
	}
	inline void showInfo()
	{
		cout << "goodD" << endl;
	}
};

#pragma region "final 的使用"
class AA
{
public:
	virtual void funA() final;
	virtual void funB();
};
class BB :public AA
{
	void funB();
};
class CC final :public AA
{
	void funB();
};

//class DD :CC //不能继承了
//{
//
//};
#pragma endregion

int main(int argc, char* argv[])
{
	Person<int> *p = new Person<int >(23);
	p->DisplayInfo();
	int a = 3, b = 5;
	cout <<"before" << a << b << endl;
	Swap(a, b);
	cout <<"after" << a << b << endl;
	/*cin >> a >> b;
	cout << a << "和" << b << "的公约数是" << GetRFC(a, b) << endl;*/

	int x, y, n;
	for (x = 1, n = 0; n < 9; y = (x + 1) * 2, x = y, n++);
	cout << "第一天共摘的桃子数量为 " << x << endl;

	//OpenExe("E:\\Study\\CodeStudy\\CSharp\\SecondTest\\SecondTest\\bin\\Debug\\netcoreapp3.1\\SecondTest.exe");
	cout << sizeof(A) << endl;
	//int* pp{ new int(4) };
	//cout << "p{ new int(4) " << (*pp) << endl;
	//A aa;
	//aa.showInfo();
	//callFun(aa);

	A aa;
	D dd;
	dd.showInfo();
	aa = dd;
	aa.showInfo();
	return 0;
}