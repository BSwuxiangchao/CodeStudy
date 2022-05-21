
#include<iostream>
#include <ctime>
using namespace std;

template <typename T>
void Swap(T& a, T& b)
{
	T temp = a;
	a = b;
	b = temp;
}
template <typename T>
void DisplayNums(T array[], int size)
{
	for (int i = 0; i < size; i++)
	{
		cout << array[i] << " ";
	}
	cout << endl;
}

//1.ð������
template <typename T>
void BubbleSort(T array[], int size)
{
	for (int i = 0; i < size-1; i++)
	{
		int isChangePos = false;
		for (int j = 0; j < size - i - 1; j++)
		{
			if (array[j]>array[j+1])
			{
				isChangePos = false;
				T temp = array[j + 1];
				array[j + 1] = array[j];
				array[j] = temp;
			}
		}
		if(!isChangePos)//�Ż����������һ������λ��û�з����仯���˳�ѭ����������
			break;
	}
}

//2.ѡ������
template <class T>
void SelectSort(T array[], int size)
{
	for (int i =0;i<size;i++)
	{
		int index = i;
		for (int j =i+1;j<size;j++)
		{
			if (array[index] > array[j])
				index = j;
		}
		if (index != i)//�ҵ���С������ֵ�����ڱ��ʼָ������
		{
			T temp = array[index];
			array[index] = array[i];
			array[i] = temp;
		}
	}
}

//3.��������
template <typename T>
void InsertSort(T array[], int size)
{
	for (int i=1;i<size;i++)
	{
		for (int j = i; j > 0; j--)
		{
			if (array[j]<array[j-1])
			{
				T temp = array[j];
				array[j] = array[j - 1];
				array[j - 1] = temp;
			}
		}
	}
}
//4��ϣ������
template <class T>
void ShellSort(T array[], int size)
{
	for (int h = size / 2; h > 0; h /= 2)//��ÿ����Ϊh�ķ���������򣬸տ�ʼn/2
	{
		for (int i = h+1;i< size;i++)//�Ը����ֲ�������в�������
		{
			int  temp = array[i];
			int k;
			for (k = i-h;k>0&& temp<array[k];k-=h)
			{
				array[k + h] = array[k];
			}
			array[k + h] = temp;
		}
	}
}

//�ϲ����������������������ϲ�
template <class T>
void mergeG(T array[], int left, int mid, int right)
{
	//����һ����ʱ����洢�ϲ�����������
	T *a = new T[right - left + 1]();
	int i = left, j = mid + 1, k = 0;
	while (i <= mid && j <= right)
	{
		if (array[i] < array[j])
		{
			a[k++] = array[i++];
		}
		else
		{
			a[k++] = array[j++];
		}
	}
	while (i <= mid)
	{
		a[k++] = array[i++];
	}
	while (j <= right)
	{
		a[k++] = array[j++];
	}
	for (i = 0; i < k; i++)
	{
		array[i] = a[i];
	}
	//delete a;
}
//5.�鲢����(�ݹ�)
template<class T>
T* MergeSort(T array[], int left,int right)
{
	if (left<right)
	{
		int mid = (left + right) / 2;
		array = MergeSort(array, left, mid);
		array = MergeSort(array, mid + 1, right);
		mergeG(array, left, mid, right);
		return array;
	}
}

//�ǵݹ�
template<class T>
void MergeSort(T array[], int size)
{
	//�������С�ֱ�Ϊ1,2,4,8...
	for (int i =1;i< size;i +=i)
	{
		//������л���
		int left = 0;
		int mid = left + i - 1;
		int right = mid + i;
		//���кϲ����������СΪi��������������ϲ�
		while (right < size)
		{
			mergeG(array, left, mid, right);
			left = right + 1;
			mid = left + i - 1;
			right = mid + i;
		}
		//����һЩ����©������û�кϲ�
		//��Ϊ������ÿ������Ĵ�С���պ�Ϊi
		if (left< size && mid < size)
		{
			mergeG(array, left, mid, size -1);
		}
	}
}

///6.��������
//ѡ���м��ֵ��Ϊ��ֵ
template <class T>
int PartitionArr(T array[], int left, int right)
{
	//ѡ����ֵ
	T temp = array[right];
	while (left != right)
	{
		while (array[left] <= temp && left <right)
		{
			left++;
		}
		if (left < right)
		{
			array[right] = array[left];
			//��ֵ��left������right�����
			right--;
		}
		while (array[right] >= temp && right > left)
		{
			right--;
		}
		if (right >left)
		{
			array[left] = array[right];
			//��ֵ��right������left�����
			left++;
		}
	}
	//��right��left���ʱ������ֵ�ŵ�left��
	array[left] = temp;
	return left;
}

template <class T>
void QuickSort(T array[],int left,int right)
{
	if (left>=right)
	{
		return;
	}
	//ѡ�������м���Ϊ��ֵ
	int pivot = (left + right) / 2;
	//����ֵ�ŵ����
	T  temp = array[right];
	array[right] = array[pivot];
	array[pivot] = temp;
	pivot = PartitionArr(array, left, right);
	QuickSort(array, left, pivot - 1);
	QuickSort(array, pivot + 1, right);
}

//7������
//�³�����
void downAdjust(int array[], int parent, int n)
{
	//��ʱ����Ҫ�³���Ԫ��
	int temp = array[parent];
	//��λ���ӽڵ��λ��
	int child = 2 * parent + 1;
	while (child<=n)
	{
		//����Һ��ӱ����Ӵ���λ���Һ���
		if (child+1 <= n && array[child]<array[child+1])
		{
			child++;
		}
		//������Ӽ�����С�ڻ���ڸ��ڵ㣬���³�����
		if (array[child] <= temp)break;
		array[parent] = array[child];
		parent = child;
		child = 2 * parent + 1;
	}
	array[parent] = temp;
}
int* headSort(int arr[], int size)
{
	//�����󶥶�
	for (int i = (size - 2) / 2;i >= 0; i--)
	{
		downAdjust(arr, i, size - 1);
	}
	//���ж�����
	for (int i = size - 1;i>= 1;i--)
	{
		//�ѶѶ�Ԫ�������һ��Ԫ�ؽ���
		Swap(arr[i], arr[0]);
		//�Ѵ��ҵĶѽ��е������ָ��ѵ�����
		downAdjust(arr, 0, i - 1);
	}
	return arr;
}

//8����������
void CountSortOld(int arr[], int size)
{
	int maxN = arr[0];
	//�õ��������ֵ���ڿ�����ʱ�ռ�
	for (int i = 0;i<size;i++)
	{
		if (maxN<arr[i])
		{
			maxN = arr[i];
		}
	}
	int *tempArr = new int[maxN+1]();
	//���������ֵ�ŵ���ʱ�����Ӧ�±�
	for (int i = 0;i<size;i++)
	{
		tempArr[arr[i]]++;
	}

	//����ʱ��������ݷŻ�ԭ����
	int k = 0;
	for (int i = 0; i <= maxN; i++)
		for (int j = 0; j < tempArr[i]; j++)
			arr[k++] = i;
	return;
}
void CountSort(int arr[], int size)
{
	int maxN = arr[0];
	int minN = arr[0];
	//�õ��������ֵ����Сֵ�Ĳ�ֵ���ڿ�����ʱ�ռ�
	for (int i = 0; i < size; i++)
	{
		if (maxN < arr[i])
		{
			maxN = arr[i];
		}
		if (arr[i] < minN)
		{
			minN = arr[i];
		}
	}
	int gap = maxN - minN+1;

	int* tempArr = new int[gap]();
	//���������ֵ�ŵ���ʱ�����Ӧ�±�
	for (int i = 0; i < size; i++)
	{
		tempArr[arr[i]-minN]++;
	}

	//����ʱ��������ݷŻ�ԭ����
	int k = 0;
	for (int i = 0; i < gap; i++)
		for (int j = 0; j < tempArr[i]; j++)
			arr[k++] = i+minN;
	return;
}
//Ͱ����
void BucketSort(int arr[], int size)
{
	int maxN = arr[0],minN = arr[0];
	for (int i = 0;i<size;i++)
	{
		if (maxN <= arr[i])
			maxN = arr[i];
		if (minN >=arr[i])
		{
			minN = arr[i];
		}
	}
	int gap = maxN - minN;
	//����gap/5+1��Ͱ
	int bucketNum = gap / 5 + 1;
	int (*tempA)[5] = new int[bucketNum][5]();
	//�����ݷŽ�Ͱ
	for (int i =0;i<size;i++)
	{
		tempA[i / bucketNum][i / 5] = arr[i];
	}
	for (int i = 0; i < bucketNum; i++)
	{
		//CountSort(tempA[i],)
	}
}

//��������
void BaseSort(int arr[], int size)
{
	int(*testArr)[5] = new int[4][5]();
	for (int i = 0 ;i<4;i++)
	{
		for (int j =0;j<5;j++)
		{
			cout << testArr[i][j] << " ";
		}
		cout << endl;
	}
}

int main2(int argc, char* argv[])
{
	char str;
	do 
	{
		cout << "origin nums:" << endl;
		int nums[] = { 1,3,8,10,7,6,5,9,4,2 };
		DisplayNums(nums, sizeof(nums) / sizeof(int));
		clock_t startT;
		cout << "****************" << endl;
		cout << "*" << endl;
		cout << "* 1 : ð������" << endl;
		cout << "* 2 : ѡ������" << endl;
		cout << "* 3 : ��������" << endl;
		cout << "* 4 : ϣ������" << endl;
		cout << "* 5 : �鲢����" << endl;
		cout << "* 6 : ��������" << endl;
		cout << "* 7 : ������" << endl;
		cout << "* 8 : ��������" << endl;
		cout << "* 9 : Ͱ����" << endl;
		cout << "* 10 : ��������" << endl;
		cout << "*" << endl;
		cout << "****************" << endl;

		cout << "ѡ��Ҫʹ�õ������㷨��" << endl;
		int ichoose = 4;
		cin >> ichoose;
		startT = clock();//��ʱ��ʼ
		switch (ichoose)
		{
		case 1:
			cout << "\nð�������㷨���" << endl;
			BubbleSort(nums, sizeof(nums) / sizeof(int));
			break;
		case 2:
			cout << "\nѡ�������㷨���" << endl;
			SelectSort(nums, sizeof(nums) / sizeof(int));
			break;
		case 3:
			cout << "\n���������㷨���" << endl;
			InsertSort(nums, sizeof(nums) / sizeof(int));
			break;
		case 4:
			cout << "\nϣ�������㷨���" << endl;
			ShellSort(nums, sizeof(nums) / sizeof(int));
			break;
		case 5:
			cout << "\n�鲢�����㷨���" << endl;
			MergeSort(nums,sizeof(nums) / sizeof(int));
			//MergeSort(nums, 0, (sizeof(nums) / sizeof(int)) - 1);
			break;
		case 6:
			cout << "\n���������㷨���" << endl;
			QuickSort(nums, 0,(sizeof(nums) / sizeof(int))-1);
			break;
		case 7:
			cout << "\n�������㷨���" << endl;
			headSort(nums, sizeof(nums) / sizeof(int));
			break;
		case 8:
			cout << "\n���������㷨���" << endl;
			CountSort(nums, sizeof(nums) / sizeof(int));
			break;
		case 9:
			cout << "\nͰ�����㷨���" << endl;
			BucketSort(nums, sizeof(nums) / sizeof(int));
			break;
		case 10:
			cout << "\n���������㷨���" << endl;
			BaseSort(nums, sizeof(nums) / sizeof(int));
			break;
		}
		DisplayNums(nums, sizeof(nums) / sizeof(int));
		cout << "��ʱ " << (double)(clock() - startT) / CLOCKS_PER_SEC << "��" << endl;
		cout << "����ʹ�������㷨��(Y/N): "<<endl;
		cin >> str;
	} while (str == 'Y');
	cout << "bug start" << endl;
	int* ptest = nullptr;
	*ptest = 5;
	cout << "bug end" << endl;
	return 0;
}