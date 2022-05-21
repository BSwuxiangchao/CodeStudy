
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

//1.冒泡排序
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
		if(!isChangePos)//优化，如果上面一趟下来位置没有发生变化，退出循环结束排序
			break;
	}
}

//2.选择排序
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
		if (index != i)//找到最小或最大的值，和哨兵最开始指向的项交换
		{
			T temp = array[index];
			array[index] = array[i];
			array[i] = temp;
		}
	}
}

//3.插入排序
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
//4、希尔排序
template <class T>
void ShellSort(T array[], int size)
{
	for (int h = size / 2; h > 0; h /= 2)//对每组间隔为h的分组进行排序，刚开始n/2
	{
		for (int i = h+1;i< size;i++)//对各个局部分组进行插入排序
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

//合并函数，把两个有序的数组合并
template <class T>
void mergeG(T array[], int left, int mid, int right)
{
	//先用一个临时数组存储合并的有序数据
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
//5.归并排序(递归)
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

//非递归
template<class T>
void MergeSort(T array[], int size)
{
	//子数组大小分别为1,2,4,8...
	for (int i =1;i< size;i +=i)
	{
		//数组进行划分
		int left = 0;
		int mid = left + i - 1;
		int right = mid + i;
		//进行合并，对数组大小为i的数组进行两两合并
		while (right < size)
		{
			mergeG(array, left, mid, right);
			left = right + 1;
			mid = left + i - 1;
			right = mid + i;
		}
		//还有一些被遗漏的数组没有合并
		//因为不可能每个数组的大小都刚好为i
		if (left< size && mid < size)
		{
			mergeG(array, left, mid, size -1);
		}
	}
}

///6.快速排序
//选择中间的值作为轴值
template <class T>
int PartitionArr(T array[], int left, int right)
{
	//选中轴值
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
			//赋值后，left不动，right向后移
			right--;
		}
		while (array[right] >= temp && right > left)
		{
			right--;
		}
		if (right >left)
		{
			array[left] = array[right];
			//赋值后，right不动，left向后移
			left++;
		}
	}
	//当right和left相等时，把轴值放到left上
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
	//选择数组中间作为轴值
	int pivot = (left + right) / 2;
	//把轴值放到最后
	T  temp = array[right];
	array[right] = array[pivot];
	array[pivot] = temp;
	pivot = PartitionArr(array, left, right);
	QuickSort(array, left, pivot - 1);
	QuickSort(array, pivot + 1, right);
}

//7、堆排
//下沉操作
void downAdjust(int array[], int parent, int n)
{
	//临时保存要下沉的元素
	int temp = array[parent];
	//定位左孩子节点的位置
	int child = 2 * parent + 1;
	while (child<=n)
	{
		//如果右孩子比左孩子大，则定位到右孩子
		if (child+1 <= n && array[child]<array[child+1])
		{
			child++;
		}
		//如果孩子及诶按小于或等于父节点，则下沉结束
		if (array[child] <= temp)break;
		array[parent] = array[child];
		parent = child;
		child = 2 * parent + 1;
	}
	array[parent] = temp;
}
int* headSort(int arr[], int size)
{
	//构建大顶堆
	for (int i = (size - 2) / 2;i >= 0; i--)
	{
		downAdjust(arr, i, size - 1);
	}
	//进行堆排序
	for (int i = size - 1;i>= 1;i--)
	{
		//把堆顶元素与最后一个元素交换
		Swap(arr[i], arr[0]);
		//把打乱的堆进行调整，恢复堆的特性
		downAdjust(arr, 0, i - 1);
	}
	return arr;
}

//8、计数排序
void CountSortOld(int arr[], int size)
{
	int maxN = arr[0];
	//得到数组最大值用于开辟临时空间
	for (int i = 0;i<size;i++)
	{
		if (maxN<arr[i])
		{
			maxN = arr[i];
		}
	}
	int *tempArr = new int[maxN+1]();
	//遍历数组把值放到临时数组对应下标
	for (int i = 0;i<size;i++)
	{
		tempArr[arr[i]]++;
	}

	//从临时数组把数据放回原数组
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
	//得到数组最大值和最小值的差值用于开辟临时空间
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
	//遍历数组把值放到临时数组对应下标
	for (int i = 0; i < size; i++)
	{
		tempArr[arr[i]-minN]++;
	}

	//从临时数组把数据放回原数组
	int k = 0;
	for (int i = 0; i < gap; i++)
		for (int j = 0; j < tempArr[i]; j++)
			arr[k++] = i+minN;
	return;
}
//桶排序
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
	//创建gap/5+1个桶
	int bucketNum = gap / 5 + 1;
	int (*tempA)[5] = new int[bucketNum][5]();
	//把数据放进桶
	for (int i =0;i<size;i++)
	{
		tempA[i / bucketNum][i / 5] = arr[i];
	}
	for (int i = 0; i < bucketNum; i++)
	{
		//CountSort(tempA[i],)
	}
}

//基数排序
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
		cout << "* 1 : 冒泡排序" << endl;
		cout << "* 2 : 选择排序" << endl;
		cout << "* 3 : 插入排序" << endl;
		cout << "* 4 : 希尔排序" << endl;
		cout << "* 5 : 归并排序" << endl;
		cout << "* 6 : 快速排序" << endl;
		cout << "* 7 : 堆排序" << endl;
		cout << "* 8 : 计数排序" << endl;
		cout << "* 9 : 桶排序" << endl;
		cout << "* 10 : 基数排序" << endl;
		cout << "*" << endl;
		cout << "****************" << endl;

		cout << "选择要使用的排序算法：" << endl;
		int ichoose = 4;
		cin >> ichoose;
		startT = clock();//计时开始
		switch (ichoose)
		{
		case 1:
			cout << "\n冒泡排序算法输出" << endl;
			BubbleSort(nums, sizeof(nums) / sizeof(int));
			break;
		case 2:
			cout << "\n选择排序算法输出" << endl;
			SelectSort(nums, sizeof(nums) / sizeof(int));
			break;
		case 3:
			cout << "\n插入排序算法输出" << endl;
			InsertSort(nums, sizeof(nums) / sizeof(int));
			break;
		case 4:
			cout << "\n希尔排序算法输出" << endl;
			ShellSort(nums, sizeof(nums) / sizeof(int));
			break;
		case 5:
			cout << "\n归并排序算法输出" << endl;
			MergeSort(nums,sizeof(nums) / sizeof(int));
			//MergeSort(nums, 0, (sizeof(nums) / sizeof(int)) - 1);
			break;
		case 6:
			cout << "\n快速排序算法输出" << endl;
			QuickSort(nums, 0,(sizeof(nums) / sizeof(int))-1);
			break;
		case 7:
			cout << "\n堆排序算法输出" << endl;
			headSort(nums, sizeof(nums) / sizeof(int));
			break;
		case 8:
			cout << "\n计数排序算法输出" << endl;
			CountSort(nums, sizeof(nums) / sizeof(int));
			break;
		case 9:
			cout << "\n桶排序算法输出" << endl;
			BucketSort(nums, sizeof(nums) / sizeof(int));
			break;
		case 10:
			cout << "\n基数排序算法输出" << endl;
			BaseSort(nums, sizeof(nums) / sizeof(int));
			break;
		}
		DisplayNums(nums, sizeof(nums) / sizeof(int));
		cout << "耗时 " << (double)(clock() - startT) / CLOCKS_PER_SEC << "秒" << endl;
		cout << "继续使用排序算法吗(Y/N): "<<endl;
		cin >> str;
	} while (str == 'Y');
	cout << "bug start" << endl;
	int* ptest = nullptr;
	*ptest = 5;
	cout << "bug end" << endl;
	return 0;
}