// treeDataStruct.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include <iostream>
using namespace std;
typedef struct _BTNode
{
    char data;

    _BTNode* LChild, * RChild;
}BTNode;

void CreateBTree(BTNode*&root)
{
    char chData;
    std::cin >> chData;
    
    if (chData == '#')
        return;
    else
    {
        BTNode* p = new BTNode;
        p->data = chData;
        p->LChild = p->RChild = NULL;
        root = p;
		CreateBTree((p->LChild));
		CreateBTree((p->RChild));
    }
}

void PreVisit(BTNode* root)
{
    if (root == NULL)
        return;
	std::cout << root->data<<" ";
	PreVisit(root->LChild);
	PreVisit(root->RChild);
}
void InVisit(BTNode* root)
{
	if (root == NULL)
		return;
	InVisit(root->LChild);
	std::cout << root->data << " ";
	InVisit(root->RChild);
}
void HostVisit(BTNode* root)
{
	if (root == NULL)
		return;
	HostVisit(root->LChild);
	HostVisit(root->RChild);
	std::cout << root->data << " ";
}
void LevelVisit(BTNode* root)
{
	const int maxsize = 5;
	int front = 0, rear = 0;
	BTNode* que[maxsize];
	BTNode* q;
	if (root != NULL)
	{
		rear = (rear + 1) % maxsize;
		que[rear] = root;
		while (front != rear)
		{
			front = (front + 1) % maxsize;
			q = que[front];
			cout << q->data << " ";
			if (q->LChild != NULL)
			{
				rear = (rear + 1) % maxsize;
				que[rear] = q->LChild;
			}
			if (q->RChild != NULL)
			{
				rear = (rear + 1) % maxsize;
				que[rear] = q->RChild;
			}
		}
	}
}
int GetDepth(BTNode* root)
{
	if (root == NULL)
		return 0;
	int iLD = GetDepth(root->LChild);
	int iRD = GetDepth(root->RChild);
	return (iLD > iRD ? (iLD + 1) : (iRD + 1));
}
int main()
{
	std::cout << "Hello World!\n";

    BTNode* root;
	std::cout << "\n前序创建二叉树\n";
	CreateBTree(root);
	std::cout << "\n前序访问二叉树\n";
    PreVisit(root);
	std::cout << "\n中序访问二叉树\n";
	InVisit(root);
	std::cout << "\n后序访问二叉树\n";
	HostVisit(root);
	std::cout << "\n层次访问二叉树\n";
	LevelVisit(root);
	std::cout << "\n此树深度\n";
	std::cout<<GetDepth(root);
	return 0;
}

// 运行程序: Ctrl + F5 或调试 >“开始执行(不调试)”菜单
// 调试程序: F5 或调试 >“开始调试”菜单

// 入门使用技巧: 
//   1. 使用解决方案资源管理器窗口添加/管理文件
//   2. 使用团队资源管理器窗口连接到源代码管理
//   3. 使用输出窗口查看生成输出和其他消息
//   4. 使用错误列表窗口查看错误
//   5. 转到“项目”>“添加新项”以创建新的代码文件，或转到“项目”>“添加现有项”以将现有代码文件添加到项目
//   6. 将来，若要再次打开此项目，请转到“文件”>“打开”>“项目”并选择 .sln 文件
