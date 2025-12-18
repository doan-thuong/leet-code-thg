using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Solution
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public bool CheckPalindromic(string a)
    {
        if (a.Length == 1) return true;
        bool check = false;
        for (int i = 0; i < Math.Floor((double)a.Length / 2); i++)
        {
            if (i == a.Length - i - 1) break;
            char first = a[i];
            char last = a[a.Length - i - 1];

            if (first.Equals(last))
            {
                check = true;
            }
            else
            {
                return false;
            }
        }

        return check;
    }
    public string FindPalindromicSubstring(string a)
    {
        int l = 0, r = 0;
        string result = a[0].ToString();
        while (r < a.Length)
        {
            string aSub = a.Substring(l, r - l + 1);
            if (CheckPalindromic(aSub))
            {
                result = result.Length < aSub.Length ? aSub : result;
            }
            r++;

            if ((r >= a.Length && l == 0) || (l < r && r >= a.Length))
            {
                r = l + result.Length;
                l++;
            }
        }
        return result;
    }
    public string StringZigZac(string s, int target)
    {
        if (s.Length == 1 || target == 1) return s;
        int cycleLen = 2 * target - 2;
        StringBuilder result = new();
        for (int i = 0; i < target; i++)
        {
            int k = 0;
            while (true)
            {
                int idx1 = i + k * cycleLen;
                if (idx1 >= s.Length) break;
                result.Append(s[idx1]);

                int idx2 = (k + 1) * cycleLen - i;
                if (i != 0 && i != target - 1 && idx2 < s.Length)
                {
                    result.Append(s[idx2]);
                }

                if (result.Length == s.Length) return result.ToString();
                k++;
            }
        }

        return result.ToString();
    }
    public int ReverseInt(int inp)
    {
        if (inp == int.MinValue) return 0;
        string strInp = Math.Abs(inp).ToString();
        int result = 0;
        Span<char> resultSpan = stackalloc char[strInp.Length];

        for (int i = strInp.Length - 1; i >= 0; i--)
        {
            resultSpan[strInp.Length - 1 - i] = strInp[i];
        }
        try
        {
            result = int.Parse(resultSpan.ToString());
            if (inp < 0) result = -result;
            return result;
        }
        catch (Exception)
        {
            return 0;
        }
    }
    public int GetInt(string str)
    {
        str = str.Trim();
        try
        {
            if (str.Length == 1)
            {
                if (!int.TryParse(str, out _)) return 0;

                return int.Parse(str);
            }
            if (str.Length > 200 || str.Length == 0) return 0;
        }
        catch
        {
            return 0;
        }

        int i = 0;
        bool isLessZero = false;
        if ("-".Equals(str[0].ToString()))
        {
            i = 1;
            isLessZero = true;
        }
        if ("+".Equals(str[0].ToString()))
        {
            i = 1;
        }

        StringBuilder builder = new();
        while (i < str.Length)
        {
            char strCheck = str[i];
            if (!int.TryParse(str[i].ToString(), out _)) break;

            if ("0".Equals(str[i].ToString()) && builder.Length == 0)
            {
                i++;
                continue;
            }

            builder.Append(str[i]);

            if (builder.Length > 10) break;
            i++;
        }

        int result = 0;

        try
        {
            result = int.Parse(builder.ToString());
        }
        catch (OverflowException)
        {
            if ("-".Equals(str[0].ToString()))
            {
                return int.MinValue;
            }
            else
            {
                return int.MaxValue;
            }
        }
        catch (Exception)
        {
            return 0;
        }

        return isLessZero ? -result : result;
    }
    public bool IsPalindrome(int x)
    {
        if (x < 0) return false;

        char[] chars = x.ToString().ToCharArray();

        int mid = chars.Length / 2;

        int i = 0;
        while (i <= mid)
        {
            if (!chars[i].Equals(chars[chars.Length - i - 1]))
            {
                return false;
            }
            i++;
        }

        return true;
    }
    public int MaxArea(int[] a)
    {
        int l = 0, r = a.Length - 1, result = 0;

        while (l < r)
        {
            int currentResult = Math.Min(a[r], a[l]) * (r - l);
            result = Math.Max(result, currentResult);
            if (a[r] < a[l])
            {
                r--;
            }
            else
            {
                l++;
            }
        }

        return result;
    }
    public string GetStr(Dictionary<int, string> config, int target)
    {
        int[] intSameArr = { 4, 5, 9, 40, 50, 90, 400, 500, 900 };
        Dictionary<int, int> intSameDict = intSameArr.Select((value, index) => new { value, index }).ToDictionary(pair => pair.value, pair => pair.index);

        StringBuilder builder = new();

        if (target >= 1000)
        {
            while (target > 0)
            {
                builder.Append(config[1000]);
                target -= 1000;
            }
        }
        else

        if (target > 500 && target < 900)
        {
            builder.Append(config[500]);
            target -= 500;
            while (target > 0)
            {
                builder.Append(config[100]);
                target -= 100;
            }
        }
        else

        if (target >= 100 && target < 400)
        {
            while (target > 0)
            {
                builder.Append(config[100]);
                target -= 100;
            }
        }
        else

        if (target > 50 && target < 90)
        {
            builder.Append(config[50]);
            target -= 50;
            while (target > 0)
            {
                builder.Append(config[10]);
                target -= 10;
            }
        }
        else

        if (target >= 10 && target < 40)
        {
            while (target > 0)
            {
                builder.Append(config[10]);
                target -= 10;
            }
        }
        else

        if (target > 5 && target < 9)
        {
            builder.Append(config[5]);
            target -= 5;
            while (target > 0)
            {
                builder.Append(config[1]);
                target -= 1;
            }
        }

        if (intSameDict.ContainsKey(target))
        {
            return config[target];
        }

        return builder.ToString();
    }
    public string IntToRoman(int a)
    {
        Dictionary<int, string> config = new()
        {
            {1000, "M"},
            {900, "CM"},
            {500, "D"},
            {400, "CD"},
            {100, "C"},
            {90, "XC"},
            {50, "L"},
            {40, "XL"},
            {10, "X"},
            {9, "IX"},
            {5, "V"},
            {4, "IV"},
            {1, "I"},
        };

        StringBuilder result = new();

        foreach (int val in config.Keys)
        {
            while (a >= val)
            {
                a -= val;
                result.Append(config[val]);
            }
        }
        return result.ToString();
    }
    public int RomanToInt(string a)
    {
        Dictionary<string, int> dictSpecial = new(){
            {"I", 1},
            {"X", 10},
            {"C", 100},
        };

        Dictionary<string, int> config = new()
        {
            {"M", 1000},
            {"CM", 900},
            {"D", 500},
            {"CD", 400},
            {"C", 100},
            {"XC", 90},
            {"L", 50},
            {"XL", 40},
            {"X", 10},
            {"IX", 9},
            {"V", 5},
            {"IV", 4},
            {"I", 1},
        };

        int ind = 0;
        int result = 0;

        while (ind < a.Length)
        {
            if (dictSpecial.ContainsKey(a[ind].ToString()) && ind < a.Length - 1)
            {
                string strSpecial = a[ind].ToString() + a[ind + 1].ToString();
                if (config.ContainsKey(strSpecial))
                {
                    result += config[strSpecial];
                    ind += 2;
                    continue;
                }
            }
            result += config[a[ind].ToString()];
            ind++;
        }

        return result;
    }
    public string LongestCommonPrefix(string[] strs)
    {
        int lengthMin = int.MaxValue;
        foreach (var item in strs)
        {
            lengthMin = Math.Min(lengthMin, item.Length);
        }

        int r = 0;
        for (int ind = 0; ind < lengthMin; ind++)
        {
            var firstChar = strs[0][ind];
            foreach (var item in strs)
            {
                if (!firstChar.Equals(item[ind]))
                {
                    return strs[0][..r];
                }
            }
            r++;
        }

        return strs[0][..r];
    }
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        // HashSet<int> config = new HashSet<int>(nums);
        IList<IList<int>> result = new List<IList<int>>();

        Array.Sort(nums);

        for (int i = 0; i < nums.Length; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1]) continue;
            int l = i + 1, r = nums.Length - 1;
            while (l < r)
            {
                if (nums[i] + nums[l] + nums[r] == 0)
                {
                    result.Add(new List<int> { nums[i], nums[l], nums[r] });

                    while (l < r && nums[l] == nums[l + 1]) l++;
                    while (l < r && nums[r] == nums[r - 1]) r--;

                    l++;
                    r--;
                }
                else if (nums[i] + nums[l] + nums[r] < 0)
                {
                    l++;
                }
                else
                {
                    r--;
                }
            }
        }
        return result;
    }
    public int ThreeSumClosest(int[] nums, int target)
    {
        int result = int.MaxValue;

        Array.Sort(nums);

        for (int i = 0; i < nums.Length; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1]) continue;
            int l = i + 1, r = nums.Length - 1;
            while (l < r)
            {
                int sum = nums[i] + nums[l] + nums[r];

                if (Math.Abs(sum - target) < Math.Abs(result - target))
                {
                    result = sum;
                }
                if (sum < target)
                {
                    l++;
                }
                else
                {
                    r--;
                }
            }
        }
        return result;
    }
    public IList<string> LetterCombinations(string digits)
    {
        if (digits.Length == 0) return new List<string>();

        Dictionary<string, List<char>> config = new()
        {
            {"2", new(){'a', 'b', 'c'}},
            {"3", new(){'d', 'e', 'f'}},
            {"4", new(){'g', 'h', 'i'}},
            {"5", new(){'j', 'k', 'l'}},
            {"6", new(){'m', 'n', 'o'}},
            {"7", new(){'p', 'q', 'r', 's'}},
            {"8", new(){'t', 'u', 'v'}},
            {"9", new(){'w', 'x', 'y', 'z'}}
        };

        IList<string> result = new List<string>();

        void BackTrack(int index, string currentString)
        {
            if (index == digits.Length)
            {
                result.Add(currentString);
                return;
            }

            char currentDigit = digits[index];
            var listChars = config[currentDigit.ToString()];

            foreach (var item in listChars)
            {
                BackTrack(index + 1, currentString + item);
            }
        }

        BackTrack(0, "");

        return result;
    }
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        IList<IList<int>> result = new List<IList<int>>();

        Array.Sort(nums);

        for (int i = 0; i < nums.Length - 3; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1]) continue;

            for (int j = i + 1; j < nums.Length - 2; j++)
            {
                if (j > i + 1 && nums[j] == nums[j - 1]) continue;

                int l = j + 1, r = nums.Length - 1;
                while (l < r)
                {
                    int sum = nums[i] + nums[j] + nums[l] + nums[r];
                    if (sum == target)
                    {
                        result.Add(new List<int> { nums[i], nums[j], nums[l], nums[r] });
                        l++;
                        r--;
                        while (l < r && nums[l] == nums[l - 1]) l++;
                        while (l < r && nums[r] == nums[r + 1]) r--;
                    }
                    else if (sum < target)
                    {
                        l++;
                    }
                    else
                    {
                        r--;
                    }
                }
            }
        }

        return result;
    }
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        ListNode dummy = new(0)
        {
            next = head
        };
        ListNode slow = dummy, fast = dummy;

        int count = 0;

        while (fast.next != null)
        {
            if (count < n)
            {
                fast = fast.next;
                count++;
                continue;
            }
            slow = slow.next;
            fast = fast.next;
        }

        slow.next = slow.next.next;
        return dummy.next;
    }
    public bool IsValid(string s)
    {
        if (s.Length % 2 != 0) return false;

        Dictionary<char, char> config = new()
        {
            {'(',')'},
            {'{','}'},
            {'[',']'},
        };

        Stack<char> stacks = new();
        foreach (var ch in s)
        {
            if (config.ContainsKey(ch))
            {
                stacks.Push(ch);
            }
            else if (config.ContainsValue(ch))
            {
                if (stacks.Count == 0 || config[stacks.Peek()] != ch)
                    return false;

                stacks.Pop();
            }
        }

        return stacks.Count == 0;
    }
    public ListNode MergeTwoLinked(ListNode list1, ListNode list2)
    {
        if (list1 == null) return list2;
        if (list2 == null) return list1;
        ListNode node, head;
        if (list1.val < list2.val)
        {
            head = node = list1;
            list1 = list1.next;
        }
        else
        {
            head = node = list2;
            list2 = list2.next;
        }

        while (list1 != null && list2 != null)
        {
            if (list1.val < list2.val)
            {
                node.next = list1;
                list1 = list1.next;
            }
            else
            {
                node.next = list2;
                list2 = list2.next;
            }
            node = node.next;
        }
        node.next = list1 ?? list2;
        return head;
    }
    public ListNode MergeKLists(ListNode[] lists)
    {
        var minHeap = new PriorityQueue<ListNode, int>();
        ListNode dummy = new(0);
        var current = dummy;
        foreach (var item in lists)
        {
            if (item != null)
                minHeap.Enqueue(item, item.val);
        }

        while (minHeap.Count > 0)
        {
            var node = minHeap.Dequeue();
            current.next = node;
            current = current.next;

            if (node.next != null) minHeap.Enqueue(node.next, node.next.val);
        }

        return dummy.next;
    }
    public int RemoveDuplicate(int[] arr)
    {
        int j = 1;

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] != arr[i - 1])
            {
                arr[j] = arr[i];
                j++;
            }
        }

        return j;
    }
    public int RemoveElement(int[] nums, int val)
    {
        int w = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != val)
            {
                nums[w] = nums[i];
                w++;
            }
        }

        return w;
    }
    public int StrStr(string haystack, string needle)
    {
        if (haystack == needle) return 0;
        if (haystack.Length < needle.Length)
        {
            return -1;
        }
        for (int i = 0; i < haystack.Length - needle.Length; i++)
        {
            if (haystack[i] == needle[0])
            {
                if (haystack.Substring(i, needle.Length) == needle)
                {
                    return i;
                }
            }
        }
        return -1;
    }
    public int Divide(int dividend, int divisor)
    {
        if (dividend == int.MinValue && divisor == -1)
            return int.MaxValue;
        double result = dividend / divisor;
        return (int)Math.Truncate(result);
    }
    public int LongestValidParentheses(string s)
    {
        Stack<int> parentheses = new();

        if (s.Length <= 1) return 0;

        int result = 0;
        parentheses.Push(-1);

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
            {
                parentheses.Push(i);
            }

            if (s[i] == ')')
            {
                parentheses.Pop();
                if (parentheses.Count == 0)
                {
                    parentheses.Push(i);
                }
                else
                {
                    result = Math.Max(i - parentheses.Peek(), result);
                }
            }
        }

        return result;
    }
    public int Search(int[] nums, int target)
    {
        int l = 0, r = nums.Length - 1;

        while (l <= r)
        {
            int mid = l + (r - l) / 2;

            if (nums[mid] == target) return mid;
            if (nums[r] == target) return r;
            if (nums[l] == target) return l;

            if (nums[mid] >= nums[l])
            {
                if (nums[l] <= target && target < nums[mid])
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }
            else
            {
                if (nums[mid] < target && target <= nums[r])
                {
                    l = mid + 1;
                }
                else
                {
                    r = mid - 1;
                }
            }
        }

        return -1;
    }
    public int[] SearchRange(int[] nums, int target)
    {
        int l = 0, r = nums.Length - 1, indexMin = -1, indexMax = -1;
        while (l <= r)
        {
            int mid = l + (r - l) / 2;

            if (nums[mid] >= target)
            {
                indexMin = nums[mid] == target ? mid : indexMin;
                r = mid - 1;
            }
            else
            {
                l = mid + 1;
            }
        }

        l = 0; r = nums.Length - 1;

        while (l <= r)
        {
            int mid = l + (r - l) / 2;

            if (nums[mid] <= target)
            {
                indexMax = nums[mid] == target ? mid : indexMax;
                l = mid + 1;
            }
            else
            {
                r = mid - 1;
            }
        }

        return new int[] { indexMin, indexMax };
    }
    public int SearchInsert(int[] nums, int target)
    {
        int l = 0, r = nums.Length - 1;
        while (l <= r)
        {
            int mid = l + (r - l) / 2;

            if (nums[mid] == target) return mid;

            if (nums[mid] < target)
            {
                l = mid + 1;
            }
            else
            {
                r = mid - 1;
            }
        }

        return l;
    }
    static string Read(string str)
    {
        StringBuilder build = new();
        int count = 1;

        for (int i = 1; i <= str.Length; i++)
        {
            if (i < str.Length && str[i] == str[i - 1])
            {
                count++;
            }
            else
            {
                build.Append($"{count}{str[i - 1]}");
                count = 1;
            }
        }

        return build.ToString();
    }
    public string CountAndSay(int n)
    {
        // if (n == 1) return "1";

        // string prev = CountAndSay(n - 1);
        // return Read(prev);
        string result = "1";

        for (int i = 2; i <= n; i++)
        {
            result = Read(result);
        }

        return result;
    }
    public string Multiply(string a, string b)
    {
        if (a == "0" || b == "0") return "0";
        StringBuilder result = new();

        int[] nums = new int[a.Length + b.Length];

        for (int i = a.Length - 1; i >= 0; i--)
        {
            var digitA = a[i] - '0';
            for (int j = b.Length - 1; j >= 0; j--)
            {
                var digitB = b[j] - '0';
                var product = digitA * digitB;

                var sum = product + nums[i + j + 1];
                nums[i + j + 1] = sum % 10;
                nums[i + j] += sum / 10;
            }
        }

        bool started = false;
        foreach (var x in nums)
        {
            if (x != 0 || started)
            {
                result.Append(x);
                started = true;
            }
        }

        if (result.Length == 0) return "0";

        return result.ToString();
    }
    public int LenghtOfLastWord(string s)
    {
        s = s.Trim();
        for (var i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] == ' ')
            {
                return s.Length - i - 1;
            }
        }

        return s.Length;
    }
    public int[] PlusOne(int[] nums)
    {
        int cache = 0;
        int k = 1;
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            int j = nums[i] + k + cache;
            k = 0;
            if (j > 9)
            {
                cache = 1;
                j -= 10;
                nums[i] = j;
            }
            else
            {
                cache = 0;
                nums[i] = j;
            }

            if (cache == 0)
            {
                break;
            }
        }
        if (cache != 0)
        {
            Array.Resize(ref nums, nums.Length + 1);
            Array.Copy(nums, 0, nums, 1, nums.Length - 1);
            nums[0] = 1;
        }

        return nums;
    }
    public string AddBinary(string a, string b)
    {
        int i = a.Length - 1, j = b.Length - 1;
        StringBuilder build = new();
        var carry = 0;

        while (i >= 0 || j >= 0 || carry > 0)
        {
            int valA = i < 0 ? 0 : a[i] - '0';
            int valB = j < 0 ? 0 : b[j] - '0';

            var sum = valA + valB + carry;
            // build.Insert(0, sum % 2);
            build.Append(sum % 2);
            carry = sum / 2;

            i--;
            j--;
        }

        char[] arr = build.ToString().ToCharArray();
        Array.Reverse(arr);

        return new string(arr);
    }
    public int Sqrt(int num)
    {
        if (num == 1) return 1;
        int i = Math.Min(num / 2, 46340);
        while (i * i > num)
        {
            i--;
        }
        return i;
    }
    public int ClimbStairs(int n)
    {
        int ClimbStairs(int num, Dictionary<int, int> memo)
        {
            if (num == 0 || num == 1)
            {
                return 1;
            }

            if (!memo.ContainsKey(num))
            {
                memo[num] = ClimbStairs(num - 1, memo) + ClimbStairs(num - 2, memo);
            }

            return memo[num];
        }
        Dictionary<int, int> memo = new();
        return ClimbStairs(n, memo);
    }
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        if (nums1.Length == 0 || nums2.Length == 0) return;
        if (nums1.Length < nums2.Length)
        {
            (nums1, nums2) = (nums2, nums1);
            (m, n) = (n, m);
        }

        for (int i = 0; i <= nums2.Length - 1; i++)
        {
            nums1[nums1.Length - 1 - i] = nums2[i];
        }

        Array.Sort(nums1);
    }
    public double MyPow(double x, int n)
    {
        if (x == 1) return 1;
        if (n == 0) return 1;

        double result = 1;

        if (n == int.MinValue)
        {
            result *= x;
            n++;
        }

        int i = Math.Abs(n);

        if (i % 2 != 0)
        {
            result *= x;
            i -= 1;
        }

        while (i >= 1)
        {
            if (i % 2 != 0)
            {
                result *= x;
            }
            x *= x;
            i /= 2;
        }

        return n > 0 ? result : 1 / result;
    }
    public int MaxSubArray(int[] nums)
    {
        int global = nums[0], better = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            better = Math.Max(nums[i], better + nums[i]);
            global = better > global ? better : global;
        }

        return global;
    }
    public IList<int> SpiralOrder(int[][] matrix)
    {
        int L = 0, R = matrix[0].Length - 1, T = 0, B = matrix.Length - 1;

        IList<int> result = new List<int>();

        while (T <= B && L <= R)
        {
            for (int i = L; i <= R; i++)
            {
                result.Add(matrix[T][i]);
            }
            T++;
            for (int i = T; i <= B; i++)
            {
                result.Add(matrix[i][R]);
            }
            R--;
            if (T <= B)
            {
                for (int i = R; i >= L; i--)
                {
                    result.Add(matrix[B][i]);
                }
                B--;
            }
            if (L <= R)
            {
                for (int i = B; i >= T; i--)
                {
                    result.Add(matrix[i][L]);
                }
                L++;
            }
        }
        return result;
    }

    public static void Main(string[] args)
    {
        // DateTime start = DateTime.Now;

        Solution solution = new();

        #region nhập input để test liên tục
        int[] nums = { 4, 5, 6, 7, 0, 1, 2 };
        string inputKey = Console.ReadLine();
        while (inputKey != "exit")
        {
            // int target = 3;
            // string result = solution.IntToRoman(int.Parse(inputKey));
            int result = solution.Search(nums, int.Parse(inputKey));
            Console.WriteLine(result);
            inputKey = Console.ReadLine();
        }
        #endregion

        // int[] nums = { 4, 5, 0, 1, 2, 3 };
        // int val = 5;
        // int haystack = 10;
        // int needle = 3;
        // string a = "()()";
        // Console.WriteLine($"kq: {solution.Search(nums, val)}");

        // int[] a = { 10, 20, 30, 40, 50, 60, 70, 80, 90 };
        // int target = 1;
        // string[] inp = { "flower", "flow", "flight" };
        // Console.WriteLine($"result: {solution.ThreeSumClosest(a, target)}");

        // var result = solution.ThreeSumClosest(a, target);
        // foreach (var item in result)
        // {
        //     foreach (int i in item)
        //     {
        //         Console.Write(i);
        //     }
        //     Console.WriteLine();
        // }

        #region nhập input để test liên tục với kết quả là list
        // string inputKey = Console.ReadLine();
        // while (inputKey != "exit")
        // {
        //     var result = solution.LetterCombinations(inputKey);
        //     foreach (var item in result)
        //     {
        //         // foreach (int i in item)
        //         // {
        //         //     Console.Write(i);
        //         // }
        //         Console.WriteLine(item);
        //     }
        //     inputKey = Console.ReadLine();
        // }
        #endregion

        // DateTime end = DateTime.Now;
        // Console.WriteLine($"Time: {end - start}");
    }
}
