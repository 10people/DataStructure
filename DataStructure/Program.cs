using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestRegex();
            TestSort();
            //TestFind();
            //TestString();
            //TestMyList();
            //TestMyArrayList();
            //TestBiTree();
        }

        static void TestRegex()
        {
            Regex temp = new Regex("f{1}ck");
            MatchCollection temp2 = temp.Matches("fuck you.");
            foreach (Match item in temp2)
            {
                Console.WriteLine("Find match at: " + item.Index);
                foreach (var capture in item.Captures)
                {
                    Console.WriteLine("Find match is: " + capture);
                }
            }
        }

        static void TestSort()
        {
            List<int> originalList = new List<int>()
            {
                11,24,11,24,11,234,1234,1223,7324,16514,11,5412,5542,9874,65,8,5,9,5,6,8,4,5,4,3,56,5,8,8,5,56,5,5,4,8,5,4,8,5,2,5
            };
            List<int> finalList = new List<int>();

            DateTime originalTime = new DateTime();

            Console.WriteLine("BubbleSort");
            originalTime = DateTime.Now;
            finalList = BubbleSort(new List<int>(originalList));
            Console.WriteLine((DateTime.Now - originalTime).TotalMilliseconds);
            Console.WriteLine(finalList.Select(item => item.ToString()).Aggregate((i, j) => (i + "," + j)));

            Console.WriteLine("SimpleSelectSort");
            originalTime = DateTime.Now;
            finalList = SimpleSelectSort(new List<int>(originalList));
            Console.WriteLine((DateTime.Now - originalTime).TotalMilliseconds);
            Console.WriteLine(finalList.Select(item => item.ToString()).Aggregate((i, j) => (i + "," + j)));

            Console.WriteLine("InsertSort");
            originalTime = DateTime.Now;
            finalList = InsertSort(new List<int>(originalList));
            Console.WriteLine((DateTime.Now - originalTime).TotalMilliseconds);
            Console.WriteLine(finalList.Select(item => item.ToString()).Aggregate((i, j) => (i + "," + j)));

            Console.WriteLine("ShellSort");
            originalTime = DateTime.Now;
            finalList = ShellSort(new List<int>(originalList));
            Console.WriteLine((DateTime.Now - originalTime).TotalMilliseconds);
            Console.WriteLine(finalList.Select(item => item.ToString()).Aggregate((i, j) => (i + "," + j)));

            Console.WriteLine("HeapSort");
            originalTime = DateTime.Now;
            var heap = ConstructHeap(new List<int>(originalList));
            finalList = HeapSort(heap);
            Console.WriteLine((DateTime.Now - originalTime).TotalMilliseconds);
            Console.WriteLine(finalList.Select(item => item.ToString()).Aggregate((i, j) => (i + "," + j)));

            Console.WriteLine("MergingSort");
            originalTime = DateTime.Now;
            finalList = MergingSort(new List<int>(originalList));
            Console.WriteLine((DateTime.Now - originalTime).TotalMilliseconds);
            Console.WriteLine(finalList.Select(item => item.ToString()).Aggregate((i, j) => (i + "," + j)));

            Console.WriteLine("QuickSort");
            originalTime = DateTime.Now;
            finalList = QuickSort(new List<int>(originalList));
            Console.WriteLine((DateTime.Now - originalTime).TotalMilliseconds);
            Console.WriteLine(finalList.Select(item => item.ToString()).Aggregate((i, j) => (i + "," + j)));

            Console.WriteLine("QuickSortClassic");
            var tempList = new List<int>()
            {
                24,11,234,1234,1223,7324,16514,5412,5542,9874,8,4,5,2
            };
            originalTime = DateTime.Now;
            QuickSortClassic(tempList, 0, tempList.Count - 1);
            Console.WriteLine((DateTime.Now - originalTime).TotalMilliseconds);
            Console.WriteLine(tempList.Select(item => item.ToString()).Aggregate((i, j) => (i + "," + j)));
        }

        static void TestFind()
        {
            List<int> originalList = new List<int>()
            {
                11,24,11,24,11,234,1234,1223,7324,16514,11,5412,5542,9874,65,8,5,9,5,6,8,4,5,4,3,56,5,8,8,5,56,5,5,4,8,5,4,8,5,2,5
            };
            List<int> finalList = new List<int>();

            DateTime originalTime = new DateTime();

            finalList = QuickSort(new List<int>(originalList));

            Console.WriteLine("SequenceFind");
            originalTime = DateTime.Now;
            Console.WriteLine(SequenceFind(5542, finalList));
            Console.WriteLine((DateTime.Now - originalTime).TotalMilliseconds);

            Console.WriteLine("BinaryFind");
            originalTime = DateTime.Now;
            Console.WriteLine(BinaryFind(5542, finalList, 0, finalList.Count - 1));
            Console.WriteLine((DateTime.Now - originalTime).TotalMilliseconds);
        }

        static void TestString()
        {
            DateTime originalTime = new DateTime();

            Console.WriteLine("string vs StringBuilder");
            int size = 100;
            for (int i = 0; i <= 3; i++)
            {
                Console.WriteLine("StringBuilder");
                originalTime = DateTime.Now;
                BuildSB(size);
                Console.WriteLine((DateTime.Now - originalTime).TotalMilliseconds);

                Console.WriteLine("string");
                originalTime = DateTime.Now;
                BuildString(size);
                Console.WriteLine((DateTime.Now - originalTime).TotalMilliseconds);
                size *= 10;
            }
        }

        static void TestMyList()
        {
            MyList<string> temp = new MyList<string>();

            temp.Add("fuck1");
            temp.Add("fuck2");
            temp.Add("fuck3");
            temp.Add("fuck4");
            temp.Add("fuckall");

            temp.RemoveAt(3);

            for (int i = 0; i < temp.Count; i++)
            {
                Console.WriteLine(temp[i]);
            }

            Console.WriteLine("Contains fuck4: " + temp.Contains("fuck4") + temp.Find("fuck4"));
            Console.WriteLine("Contains fuck3: " + temp.Contains("fuck3") + temp.Find("fuck3"));

            temp.Insert(3, "fuck4");

            Console.WriteLine("Contains fuck4: " + temp.Contains("fuck4") + temp.Find("fuck4"));
            Console.WriteLine("Contains fuck3: " + temp.Contains("fuck3") + temp.Find("fuck3"));

            for (int i = 0; i < temp.Count; i++)
            {
                Console.WriteLine(temp[i]);
            }

            temp.Reverse();

            for (int i = 0; i < temp.Count; i++)
            {
                Console.WriteLine(temp[i]);
            }

            temp.Insert(3, "fuckbbb");
            temp.Sort();

            for (int i = 0; i < temp.Count; i++)
            {
                Console.WriteLine(temp[i]);
            }

            temp.Clear();

            for (int i = 0; i < temp.Count; i++)
            {
                Console.WriteLine(temp[i]);
            }
        }

        static void TestMyArrayList()
        {
            MyArrayList<string> temp = new MyArrayList<string>();

            temp.Add("fuck1");
            temp.Add("fuck2");
            temp.Add("fuck3");
            temp.Add("fuck4");
            temp.Add("fuckall");

            temp.RemoveAt(3);

            for (int i = 0; i < temp.Count; i++)
            {
                Console.WriteLine(temp[i]);
            }

            Console.WriteLine("Contains fuck4: " + temp.Contains("fuck4") + temp.Find("fuck4"));
            Console.WriteLine("Contains fuck3: " + temp.Contains("fuck3") + temp.Find("fuck3"));

            temp.Insert(3, "fuck4");

            Console.WriteLine("Contains fuck4: " + temp.Contains("fuck4") + temp.Find("fuck4"));
            Console.WriteLine("Contains fuck3: " + temp.Contains("fuck3") + temp.Find("fuck3"));

            for (int i = 0; i < temp.Count; i++)
            {
                Console.WriteLine(temp[i]);
            }

            temp.Reverse();

            for (int i = 0; i < temp.Count; i++)
            {
                Console.WriteLine(temp[i]);
            }

            temp.Insert(3, "fuckbbb");
            temp.Sort();

            for (int i = 0; i < temp.Count; i++)
            {
                Console.WriteLine(temp[i]);
            }

            temp.Clear();

            for (int i = 0; i < temp.Count; i++)
            {
                Console.WriteLine(temp[i]);
            }
        }

        static void TestBiTree()
        {
            BiTree<int> temp = new BiTree<int>(62);
            temp.AddLeftChild(58);
            temp.AddRightChild(88);
            temp.LeftChild.AddLeftChild(47);
            temp.LeftChild.LeftChild.AddLeftChild(35);
            temp.LeftChild.LeftChild.AddRightChild(51);
            temp.LeftChild.LeftChild.LeftChild.AddRightChild(37);
            temp.RightChild.AddLeftChild(73);
            temp.RightChild.AddRightChild(99);
            temp.RightChild.RightChild.AddLeftChild(93);

            temp.PreOrderDisplay();
            Console.WriteLine();
            temp.InOrderDisplay();
            Console.WriteLine();
            temp.PostOrderDisplay();
            Console.WriteLine();

            Console.WriteLine();

            temp = new BiTree<int>(62);
            temp.AddAsSortTree(58);
            temp.AddAsSortTree(88);
            Console.WriteLine(temp.IsAVL);
            temp.AddAsSortTree(47);
            Console.WriteLine(temp.IsAVL);
            temp.AddAsSortTree(35);
            temp.AddAsSortTree(51);
            Console.WriteLine(temp.IsAVL);
            temp.AddAsSortTree(37);
            temp.AddAsSortTree(73);
            temp.AddAsSortTree(99);
            temp.AddAsSortTree(93);
            Console.WriteLine(temp.IsAVL);

            temp.PreOrderDisplay();
            Console.WriteLine();
            temp.InOrderDisplay();
            Console.WriteLine();
            temp.PostOrderDisplay();
            Console.WriteLine();

            temp.FindInSortTree(47);

            var newTree = BiTree<int>.AdjustToAVL(temp);
            Console.WriteLine(newTree.IsAVL);

            newTree.PreOrderDisplay();
            Console.WriteLine();
            newTree.InOrderDisplay();
            Console.WriteLine();
            newTree.PostOrderDisplay();
            Console.WriteLine();

            newTree.FindInSortTree(47);
        }

        #region BiTree

        public class BiTree<T> where T : IComparable<T>
        {
            public BiTree<T> Parent { get; private set; }
            public BiTree<T> LeftChild { get; private set; }
            public BiTree<T> RightChild { get; private set; }

            public T Data
            {
                get { return data; }
                set
                {
                    this.data = value;
                    IsEmpty = false;
                }
            }

            private T data;

            public bool IsEmpty { get; private set; }
            public bool IsRoot => Parent == null;

            public int Depth => GetDepth();

            private int GetDepth()
            {
                if (IsEmpty)
                {
                    return 0;
                }

                if (LeftChild == null)
                {
                    if (RightChild == null)
                    {
                        return 1;
                    }
                    else
                    {
                        return RightChild.GetDepth() + 1;
                    }
                }
                else
                {
                    if (RightChild == null)
                    {
                        return LeftChild.GetDepth() + 1;
                    }
                    else
                    {
                        return Math.Max(LeftChild.GetDepth(), RightChild.GetDepth()) + 1;
                    }
                }
            }

            public BiTree()
            {
                IsEmpty = true;
            }

            public BiTree(T data)
            {
                Data = data;
            }

            public void AddLeftChild(T value)
            {
                if (IsEmpty)
                {
                    throw new Exception("Cannot add child to a empty tree.");
                }

                if (LeftChild != null)
                {
                    throw new Exception("Child already exists.");
                }

                LeftChild = new BiTree<T>(value);
                LeftChild.Parent = this;
            }

            public void AddRightChild(T value)
            {
                if (IsEmpty)
                {
                    throw new Exception("Cannot add child to a empty tree.");
                }

                if (RightChild != null)
                {
                    throw new Exception("Child already exists.");
                }

                RightChild = new BiTree<T>(value);
                RightChild.Parent = this;
            }

            #region Sort Tree

            public void AddAsSortTree(T value)
            {
                if (IsEmpty)
                {
                    throw new Exception("Cannot add child to a empty tree.");
                }

                if (value.CompareTo(Data) <= 0)
                {
                    TryAddToLeftChild(value);
                }
                else
                {
                    TryAddToRightChild(value);
                }
            }

            private void TryAddToLeftChild(T value)
            {
                if (LeftChild == null)
                {
                    AddLeftChild(value);
                }
                else
                {
                    LeftChild.AddAsSortTree(value);
                }
            }

            private void TryAddToRightChild(T value)
            {
                if (RightChild == null)
                {
                    AddRightChild(value);
                }
                else
                {
                    RightChild.AddAsSortTree(value);
                }
            }

            public bool FindInSortTree(T value)
            {
                if (IsEmpty)
                {
                    Console.WriteLine(value + " not found in a empty tree.");

                    return false;
                }

                if (value.CompareTo(data) == 0)
                {
                    string outputString = data.ToString();
                    BiTree<T> targetNodesChild = this;

                    while (targetNodesChild.Parent != null)
                    {
                        outputString = targetNodesChild.Parent.Data + "->" + outputString;

                        targetNodesChild = targetNodesChild.Parent;
                    }

                    Console.WriteLine(value + " found in tree: " + outputString);

                    return true;
                }
                else if (value.CompareTo(data) < 0)
                {
                    if (LeftChild != null)
                    {
                        return LeftChild.FindInSortTree(value);
                    }
                    else
                    {
                        Console.WriteLine(value + " not found.");

                        return false;
                    }
                }
                else
                {
                    if (RightChild != null)
                    {
                        return RightChild.FindInSortTree(value);
                    }
                    else
                    {
                        Console.WriteLine(value + " not found.");

                        return false;
                    }
                }
            }

            #endregion

            #region AVL Tree

            public bool IsAVL
            {
                get
                {
                    if (IsEmpty)
                    {
                        return true;
                    }

                    return isBalancedNode && (LeftChild == null || LeftChild.IsAVL) && (RightChild == null || RightChild.IsAVL);
                }
            }

            private bool isBalancedNode => Math.Abs(SubTreeDepthSubtract) <= 1;

            private int SubTreeDepthSubtract
            {
                get
                {
                    if (IsEmpty)
                    {
                        return 0;
                    }

                    int LeftSubTreeDepth = LeftChild != null ? LeftChild.Depth : 0;
                    int RightSubTreeDepth = RightChild != null ? RightChild.Depth : 0;

                    return LeftSubTreeDepth - RightSubTreeDepth;
                }
            }

            public static BiTree<T> AdjustToAVL(BiTree<T> p_rootNode)
            {
                if (p_rootNode.IsEmpty)
                {
                    return p_rootNode;
                }

                BiTree<T> rootNode = p_rootNode;
                BiTree<T> UnbalanceNode = rootNode.FindFirstUnbalancedNode();

                while (UnbalanceNode != null)
                {
                    var temp = UnbalanceNode.AdjustToAVL();
                    if (temp != null)
                    {
                        rootNode = temp;
                    }

                    UnbalanceNode = rootNode.FindFirstUnbalancedNode();
                }

                return rootNode;
            }

            private BiTree<T> FindFirstUnbalancedNode()
            {
                if (!isBalancedNode)
                {
                    return this;
                }
                else
                {
                    BiTree<T> toReturn = null;

                    if (LeftChild != null)
                    {
                        toReturn = LeftChild.FindFirstUnbalancedNode();
                    }

                    if (toReturn != null)
                    {
                        return toReturn;
                    }

                    if (RightChild != null)
                    {
                        toReturn = RightChild.FindFirstUnbalancedNode();
                    }

                    if (toReturn != null)
                    {
                        return toReturn;
                    }

                    return null;
                }
            }

            private BiTree<T> AdjustToAVL()
            {
                if (isBalancedNode)
                {
                    return null;
                }

                if (SubTreeDepthSubtract > 1)
                {
                    //Execute parent
                    if (!IsRoot)
                    {
                        if (Parent.LeftChild == this)
                        {
                            Parent.LeftChild = LeftChild;
                            LeftChild.Parent = Parent;
                        }
                        else
                        {
                            Parent.RightChild = LeftChild;
                            LeftChild.Parent = Parent;
                        }
                    }

                    var toMoveNode = LeftChild.RightChild;

                    //Rotate
                    LeftChild.RightChild = this;
                    Parent = LeftChild;

                    //Move additional node.
                    if (toMoveNode != null)
                    {
                        LeftChild = toMoveNode;
                        toMoveNode.Parent = this;
                    }
                    else
                    {
                        LeftChild = null;
                    }

                    return IsRoot ? Parent : null;
                }
                else
                {
                    if (!IsRoot)
                    {
                        if (Parent.LeftChild == this)
                        {
                            Parent.LeftChild = RightChild;
                            RightChild.Parent = Parent;
                        }
                        else
                        {
                            Parent.RightChild = RightChild;
                            RightChild.Parent = Parent;
                        }
                    }

                    var toMoveNode = RightChild.LeftChild;

                    RightChild.LeftChild = this;
                    Parent = RightChild;

                    if (toMoveNode != null)
                    {
                        RightChild = toMoveNode;
                        toMoveNode.Parent = this;
                    }
                    else
                    {
                        RightChild = null;
                    }

                    return IsRoot ? Parent : null;
                }
            }

            #endregion

            public void PreOrderDisplay()
            {
                Console.Write(Data + "\t");
                if (LeftChild != null)
                {
                    LeftChild.PreOrderDisplay();
                }
                if (RightChild != null)
                {
                    RightChild.PreOrderDisplay();
                }
            }

            public void InOrderDisplay()
            {
                if (LeftChild != null)
                {
                    LeftChild.InOrderDisplay();
                }
                Console.Write(Data + "\t");
                if (RightChild != null)
                {
                    RightChild.InOrderDisplay();
                }
            }

            public void PostOrderDisplay()
            {
                if (LeftChild != null)
                {
                    LeftChild.PostOrderDisplay();
                }
                if (RightChild != null)
                {
                    RightChild.PostOrderDisplay();
                }
                Console.Write(Data + "\t");
            }
        }

        #endregion

        #region List

        public class MyArrayList<T> where T : IComparable<T>
        {
            private T[] interArray;
            private int limitSize = 4;

            private void UpdateSize()
            {
                limitSize *= 2;
                T[] newArray = new T[limitSize];

                interArray.CopyTo(newArray, 0);
                interArray = newArray;
            }

            public int Count { get; private set; }

            public MyArrayList()
            {
                Count = 0;
                interArray = new T[limitSize];
            }

            public MyArrayList(MyList<T> myList)
            {
                Count = 0;
                interArray = new T[limitSize];

                for (int i = 0; i < myList.Count; i++)
                {
                    Add(myList[i]);
                }
            }

            public MyArrayList(List<T> list)
            {
                Count = 0;
                interArray = new T[limitSize];

                for (int i = 0; i < list.Count; i++)
                {
                    Add(list[i]);
                }
            }

            public MyArrayList(T[] array)
            {
                Count = 0;
                interArray = new T[limitSize];

                for (int i = 0; i < array.Length; i++)
                {
                    Add(array[i]);
                }
            }

            public T this[int index]
            {
                get
                {
                    if (index < 0 || index >= Count)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    return interArray[index];
                }
            }

            public void Add(T item)
            {
                if (Count >= limitSize)
                {
                    UpdateSize();
                }

                interArray[Count] = item;
                Count++;
            }

            public void RemoveAt(int index)
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                while (index < Count - 1)
                {
                    interArray[index] = interArray[index + 1];
                    index++;
                }

                Count--;
            }

            public bool Contains(T value)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    if (this[i].CompareTo(value) == 0)
                    {
                        return true;
                    }
                }

                return false;
            }

            public int Find(T value)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    if (this[i].CompareTo(value) == 0)
                    {
                        return i;
                    }
                }

                return -1;
            }

            public void Insert(int index, T value)
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (Count >= limitSize)
                {
                    UpdateSize();
                }

                T toInsert = value;

                while (index <= Count)
                {
                    Swap(ref toInsert, ref interArray[index]);
                    index++;
                }

                Count++;
            }

            public void Sort()
            {
                List<T> temp = QuickSort(this.ToList());

                Clear();

                for (int i = 0; i < temp.Count; i++)
                {
                    Add(temp[i]);
                }
            }

            private void Swap(ref T a, ref T b)
            {
                var temp = a;
                a = b;
                b = temp;
            }

            public void Reverse()
            {
                if (Count <= 1)
                {
                    return;
                }

                for (int i = 0; i < Count / 2; i++)
                {
                    Swap(ref interArray[i], ref interArray[Count - i - 1]);
                }
            }

            public T[] ToArray()
            {
                T[] toReturn = new T[Count];

                for (int i = 0; i < Count; i++)
                {
                    toReturn[i] = this[i];
                }

                return toReturn;
            }

            public List<T> ToList()
            {
                List<T> toReturn = new List<T>();

                for (int i = 0; i < Count; i++)
                {
                    toReturn.Add(this[i]);
                }

                return toReturn;
            }

            public void Clear()
            {
                Count = 0;
                limitSize = 4;
                interArray = new T[limitSize];
            }
        }

        public class MyList<T> where T : IComparable<T>
        {
            private class MyListNode<T2> where T2 : IComparable<T2>
            {
                public MyListNode<T2> Previous;
                public MyListNode<T2> Next;
                public T2 Data;

                public MyListNode(T2 item)
                {
                    Previous = null;
                    Next = null;
                    Data = item;
                }
            }

            private MyListNode<T> firstNode;

            public int Count { get; private set; }

            public MyList()
            {
                Count = 0;
                firstNode = null;
            }

            public MyList(MyList<T> myList)
            {
                Count = 0;
                firstNode = null;

                for (int i = 0; i < myList.Count; i++)
                {
                    Add(myList[i]);
                }
            }

            public MyList(List<T> list)
            {
                Count = 0;
                firstNode = null;

                for (int i = 0; i < list.Count; i++)
                {
                    Add(list[i]);
                }
            }

            public MyList(T[] array)
            {
                Count = 0;
                firstNode = null;

                for (int i = 0; i < array.Length; i++)
                {
                    Add(array[i]);
                }
            }

            public T this[int index] => GetItem(index).Data;

            private MyListNode<T> GetItem(int index)
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                MyListNode<T> toReturn = firstNode;

                while (index > 0)
                {
                    toReturn = toReturn.Next;
                    index--;
                }

                return toReturn;
            }

            public void Add(T item)
            {
                if (firstNode == null)
                {
                    firstNode = new MyListNode<T>(item);

                    firstNode.Previous = firstNode;
                    firstNode.Next = firstNode;
                }
                else
                {
                    MyListNode<T> newNode = new MyListNode<T>(item);

                    newNode.Next = firstNode;
                    newNode.Previous = firstNode.Previous;

                    firstNode.Previous = newNode;
                    newNode.Previous.Next = newNode;
                }

                Count++;
            }

            public void RemoveAt(int index)
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                MyListNode<T> toRemove = firstNode;

                while (index > 0)
                {
                    toRemove = toRemove.Next;
                    index--;
                }

                toRemove.Previous.Next = toRemove.Next;
                toRemove.Next.Previous = toRemove.Previous;

                Count--;
            }

            public bool Contains(T value)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    if (this[i].CompareTo(value) == 0)
                    {
                        return true;
                    }
                }

                return false;
            }

            public int Find(T value)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    if (this[i].CompareTo(value) == 0)
                    {
                        return i;
                    }
                }

                return -1;
            }

            public void Insert(int index, T value)
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                MyListNode<T> toInsert = new MyListNode<T>(value);

                var originalPosItem = GetItem(index);

                toInsert.Previous = originalPosItem.Previous;
                toInsert.Next = originalPosItem;
                originalPosItem.Previous.Next = toInsert;
                originalPosItem.Previous = toInsert;
                Count++;
            }

            public void Sort()
            {
                List<T> temp = QuickSort(this.ToList());

                Clear();

                for (int i = 0; i < temp.Count; i++)
                {
                    Add(temp[i]);
                }
            }

            private void Swap(MyListNode<T> current)
            {
                var temp = current.Previous;
                current.Previous = current.Next;
                current.Next = temp;
            }

            public void Reverse()
            {
                if (Count <= 1)
                {
                    return;
                }

                MyListNode<T> toOperate = firstNode;
                Swap(firstNode);

                toOperate = firstNode.Previous;
                while (toOperate != firstNode)
                {
                    Swap(toOperate);

                    toOperate = toOperate.Previous;
                }

                firstNode = firstNode.Next;
            }

            public T[] ToArray()
            {
                T[] toReturn = new T[Count];

                for (int i = 0; i < Count; i++)
                {
                    toReturn[i] = this[i];
                }

                return toReturn;
            }

            public List<T> ToList()
            {
                List<T> toReturn = new List<T>();

                for (int i = 0; i < Count; i++)
                {
                    toReturn.Add(this[i]);
                }

                return toReturn;
            }

            public void Clear()
            {
                firstNode = null;
                Count = 0;
            }
        }

        #endregion

        #region Sort Algorithm

        static void Swap(List<int> list, int index1, int index2)
        {
            int temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }

        static List<int> BubbleSort(List<int> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        Swap(list, j, j + 1);
                    }
                }
            }

            return list;
        }

        static List<int> SimpleSelectSort(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j] < list[i])
                    {
                        Swap(list, j, i);
                    }
                }
            }

            return list;
        }

        static List<int> InsertSort(List<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                int temp = list[i];

                for (int j = i - 1; ; j--)
                {
                    if (j < 0)
                    {
                        list[j + 1] = temp;
                        break;
                    }

                    if (list[j] > temp)
                    {
                        list[j + 1] = list[j];
                    }
                    else
                    {
                        list[j + 1] = temp;
                        break;
                    }
                }
            }

            return list;
        }

        static List<int> ShellSort(List<int> list)
        {
            int increment = list.Count;

            while (increment > 1)
            {
                increment = increment / 3 + 1;

                for (int toInsertIndex = increment; toInsertIndex < list.Count; toInsertIndex++)
                {
                    int temp = list[toInsertIndex];

                    for (int j = toInsertIndex - increment; ; j -= increment)
                    {
                        if (j < 0)
                        {
                            list[j + increment] = temp;
                            break;
                        }

                        if (list[j] > temp)
                        {
                            list[j + increment] = list[j];
                        }
                        else
                        {
                            list[j + increment] = temp;
                            break;
                        }
                    }
                }
            }

            return list;
        }

        static List<int> ConstructHeap(List<int> list)
        {
            List<int> returnList = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                returnList.Add(list[i]);
                AddToHeap(returnList);
            }

            return returnList;
        }

        static void AddToHeap(List<int> list)
        {
            int targetIndex = list.Count;

            while (targetIndex / 2 > 0 && list[targetIndex / 2 - 1] < list[targetIndex - 1])
            {
                var temp = list[targetIndex / 2 - 1];
                list[targetIndex / 2 - 1] = list[targetIndex - 1];
                list[targetIndex - 1] = temp;

                targetIndex /= 2;
            }
        }

        static void AdjustHeap(List<int> list)
        {
            int targetIndex = 1;

            while (targetIndex * 2 <= list.Count)
            {
                int biggerIndex;

                if (targetIndex * 2 + 1 <= list.Count)
                {
                    biggerIndex = list[targetIndex * 2 - 1] > list[targetIndex * 2] ? (targetIndex * 2) : (targetIndex * 2 + 1);
                }
                else
                {
                    biggerIndex = targetIndex * 2;
                }

                if (list[targetIndex - 1] < list[biggerIndex - 1])
                {
                    var temp = list[targetIndex - 1];
                    list[targetIndex - 1] = list[biggerIndex - 1];
                    list[biggerIndex - 1] = temp;

                    targetIndex = biggerIndex;
                }
                else
                {
                    break;
                }
            }
        }

        static List<int> HeapSort(List<int> list)
        {
            List<int> returnList = new List<int>();

            while (list.Count > 0)
            {
                returnList.Add(list[0]);
                list[0] = list[list.Count - 1];
                list.RemoveAt(list.Count - 1);

                AdjustHeap(list);
            }

            returnList.Reverse();

            return returnList;
        }

        static List<int> MergingSort(List<int> list)
        {
            if (list.Count > 2)
            {
                list = MergingLists(MergingSort(list.Where((item, index) => index < list.Count / 2).ToList()),
                    MergingSort(list.Where((item, index) => index >= list.Count / 2).ToList()));
            }
            else if (list.Count == 2)
            {
                if (list[0] > list[1])
                {
                    Swap(list, 0, 1);
                }
            }

            return list;
        }

        static List<int> MergingLists(List<int> list1, List<int> list2)
        {
            int list1Now = 0;
            int list2Now = 0;

            List<int> returnList = new List<int>();
            while (true)
            {
                if (list1Now < list1.Count && list2Now < list2.Count)
                {
                    if (list1[list1Now] < list2[list2Now])
                    {
                        returnList.Add(list1[list1Now]);
                        list1Now++;
                    }
                    else
                    {
                        returnList.Add(list2[list2Now]);
                        list2Now++;
                    }
                }
                else if (list1Now >= list1.Count)
                {
                    returnList.AddRange(list2.Where((item, index) => index >= list2Now));
                    return returnList;
                }
                else
                {
                    returnList.AddRange(list1.Where((item, index) => index >= list1Now));
                    return returnList;
                }
            }
        }

        static List<T> QuickSort<T>(List<T> list) where T : IComparable<T>
        {
            if (list == null)
            {
                return new List<T>();
            }
            else if (list.Count <= 1)
            {
                return list;
            }

            T pivot = list[0];
            return QuickSort(list.Where(item => item.CompareTo(pivot) < 0).ToList()).Concat(list.Where(item => item.CompareTo(pivot) == 0).ToList()).Concat(QuickSort(list.Where(item => item.CompareTo(pivot) > 0).ToList())).ToList();
        }

        static void QuickSortClassic(List<int> list, int first, int last)
        {
            if (list == null || list.Count <= 1 || first >= last)
            {
                return;
            }

            int pivotIndex = QuickSortPartition(list, first, last);
            QuickSortClassic(list, first, pivotIndex - 1);
            QuickSortClassic(list, pivotIndex + 1, last);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <returns>pivot index</returns>
        static int QuickSortPartition(List<int> list, int first, int last)
        {
            int lowIndex = first;
            int highIndex = last;

            int pivot = list[first];

            while (lowIndex < highIndex + 1)
            {
                while (lowIndex <= last && list[lowIndex] <= pivot)
                {
                    lowIndex++;
                }

                if (lowIndex >= highIndex + 1)
                {
                    break;
                }

                while (highIndex >= first && list[highIndex] > pivot)
                {
                    highIndex--;
                }

                if (lowIndex >= highIndex + 1)
                {
                    break;
                }

                Swap(list, lowIndex, highIndex);
            }

            Swap(list, first, highIndex);

            return highIndex;
        }

        #endregion

        #region Find Algorithm

        static int SequenceFind(int value, List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (value == list[i])
                {
                    return i;
                }
            }

            return -1;
        }

        static int BinaryFind(int value, List<int> list, int startIndex, int endIndex)
        {
            if (endIndex - startIndex < 0)
            {
                return -1;
            }

            int divideIndex = (startIndex + endIndex) / 2;

            if (list[divideIndex] == value)
            {
                return divideIndex;
            }
            else if (list[divideIndex] > value)
            {
                if (divideIndex > startIndex)
                {
                    return BinaryFind(value, list, startIndex, divideIndex - 1);
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                if (divideIndex < endIndex)
                {
                    return BinaryFind(value, list, divideIndex + 1, endIndex);
                }
                else
                {
                    return -1;
                }
            }
        }

        #endregion

        #region String

        static void BuildSB(int size)
        {
            StringBuilder sbObject = new StringBuilder();
            for (int i = 0; i <= size; i++)
                sbObject.Append("a");
        }

        static void BuildString(int size)
        {
            string stringObject = "";
            for (int i = 0; i <= size; i++)
                stringObject += "a";
        }

        #endregion
    }
}
