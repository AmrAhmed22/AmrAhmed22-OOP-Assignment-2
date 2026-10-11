
// Time  complexity O(N) 
// Space complexity O(1) 

public int MaxVowels(string s, int k)
{
    bool isvowel(char c)
    {
        return (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u');
    }

    int vowels = 0;

    for (int i = 0; i < k; i++)
    {
        if (isvowel(s[i]))
            vowels++;
    }

    int maxvowels = vowels;

    for (int i = k; i < s.Length; i++)
    {
        if (isvowel(s[i]))
            vowels++;
        if (isvowel(s[i - k]))
            vowels--;

        if (vowels > maxvowels)
            maxvowels = vowels;
    }

    return maxvowels;
}


