using System;
using System.Configuration;
using System.IO;
using System.Text;

namespace Books.BusinessLayer
{
    public class BookList
    {
        public class Node<T>
        {
            public int BirthYear;
            public T AuthorName;
            public Node<T> next;
            public Node(int birth_year, T author_name)
            {
                BirthYear = birth_year;
                AuthorName = author_name;
                next = null;
            }
        }

        public class CreateList<T> where T : IComparable<T>
        {
            protected Node<T> head = null;
            protected Node<T> tail = null;
            //This function will add the new node at the end of the list.  
            public void add(int birthYear, T authorName)
            {
                //Create new node  
                Node<T> newNode = new Node<T>(birthYear, authorName);
                //Checks if the list is empty.  
                if (head == null)
                {
                    head = newNode;
                    tail = newNode;
                    newNode.next = head;
                }
                else
                {
                    //tail will point to new node.  
                    tail.next = newNode;
                    //New node will become new tail.  
                    tail = newNode;
                    //Since, it is circular linked list tail will point to head.  
                    tail.next = head;
                }
            }
            //This function sorts the list in descending order  
            public void sortList()
            {
                //Current will point to head  
                Node<T> current = head, index = null;
                int temp;
                T authtemp;
                if (head == null)
                {
                    Console.WriteLine("List is empty");
                }
                else
                {
                    do
                    {
                        //Index will point to node next to current  
                        index = current.next;
                        while (index != head)
                        {
                            //If current node is greater than index data, swaps the data  
                            if (current.BirthYear.CompareTo(index.BirthYear) < 0)
                            {
                                temp = current.BirthYear;
                                current.BirthYear = index.BirthYear;
                                index.BirthYear = temp;
                                authtemp = current.AuthorName;
                                current.AuthorName = index.AuthorName;
                                index.AuthorName = authtemp;
                            }
                            index = index.next;
                        }
                        current = current.next;
                    } while (current.next != head);
                }
                //return current.ToString();
            }
            //Displays all the nodes in the list  
            public void display()
            {
                Node<T> current = head;
                Node<T> currentTemp = null;
                if (head == null)
                {
                    Console.WriteLine("List is empty");
                }
                else
                {
                    do
                    {
                        if (!((currentTemp != null) && currentTemp.AuthorName.Equals(current.AuthorName) && (currentTemp.BirthYear == current.BirthYear)))
                        {
                            //Prints each node by incrementing pointer.  
                           // Console.WriteLine(" " + current.BirthYear + "-" + current.AuthorName);
                            Console.WriteLine(" " + current.AuthorName);
                        }
                        currentTemp = current;
                        current = current.next;
                    } while (current != head);
                    Console.WriteLine();
                }
            }

            // Export data into CSV
            public void ExportCSV()
            {
                try
                {
                    Console.Write("Do you want to Export" + " [y/n] : ");
                    ConsoleKey response = Console.ReadKey(false).Key;
                    Console.WriteLine();
                    if (response == ConsoleKey.Y)
                    {
                        string fileName = "author.csv";
                        StringBuilder exportPath = new StringBuilder();
                        string exportDir = ConfigurationManager.AppSettings["ExportDir"].ToString();
                        exportPath.Append(exportDir).Append(fileName);
                        Console.WriteLine(string.Format("Exporting file to {0} directory.", exportDir));
                        StringBuilder sbOutput = new StringBuilder();
                        Node<T> current = head;
                        Node<T> currentTemp = null;
                        if (head == null)
                        {
                            Console.WriteLine("List is empty");
                        }
                        else
                        {
                            do
                            {
                                if (!((currentTemp != null) && currentTemp.AuthorName.Equals(current.AuthorName) && (currentTemp.BirthYear == current.BirthYear)))
                                {
                                    //Append each node by incrementing pointer.  
                                   // sbOutput.AppendLine(" " + current.BirthYear + "," + "\"" + current.AuthorName + "\"");
                                    sbOutput.AppendLine(" " + "\"" + current.AuthorName + "\"");
                                }
                                currentTemp = current;
                                current = current.next;
                            } while (current != head);
                        }
                        if (!Directory.Exists(exportDir))
                        {
                            Directory.CreateDirectory(exportDir);
                        }
                        // Create and write the csv file
                        File.WriteAllText(exportPath.ToString(), sbOutput.ToString());
                        Console.WriteLine("File Exported Successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Exiting Application.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }
    }

}
