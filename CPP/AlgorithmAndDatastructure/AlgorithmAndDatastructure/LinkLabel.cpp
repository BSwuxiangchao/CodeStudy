#include<iostream>
using namespace std;
typedef struct _Node
{
	int data;
	_Node* next;
}Node,* PNode;

//初始化单链表
void InitSingleLink(Node** head)
{
	*head = new Node();
}

void HeadInsert(PNode& head, int data)
{
	Node* p = head;
	Node* q = head->next;
	Node* sp = new Node();
	sp->data = data;
	p->next = sp;
	sp->next = q;
}

void TailInsert(PNode& head, int data)
{
	Node* p = head;
	Node* q = new Node();
	q->data = data;
	while (p->next)
	{
		p = p->next;
	}
	p->next = q;
}

void DisplayLink(PNode& head)
{
	PNode p = head;
	if (p->next != NULL)
	{
		cout << "\n the data of link table is : " << endl;
		while (p->next)
		{
			p = p->next;
			cout << p->data;
		}
	}
}

int mainLink()
{
	PNode H=NULL;
	InitSingleLink(&H);
	for (int i = 0; i < 5; i++)
	{
		HeadInsert(H, i);
		//TailInsert(H, i+1);
	}
	DisplayLink(H);
	return 0;
}