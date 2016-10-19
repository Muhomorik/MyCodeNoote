// TPL and concurrent collection.
// Src: https://msdn.microsoft.com/en-us/library/hh228604(v=vs.110).aspx

var reversedWords = new ConcurrentQueue<string>();

// Add each word in the original collection to the result whose 
// reversed word also exists in the collection.
Parallel.ForEach(words, word =>
{
    // Reverse the work.
    string reverse = new string(word.Reverse().ToArray());

    // Enqueue the word if the reversed version also exists
    // in the collection.
    if (Array.BinarySearch<string>(words, reverse) >= 0 &&
        word != reverse)
    {
        reversedWords.Enqueue(word);
    }
});