//*****************************************************************************
//** 1105. Filling Bookcase Shelbes  leetcode                                **
//** My code at the top (I broke it, easy to fix) and ChatGPT underneath     **
//** Implementation is easy, ChatGPT made faster code                   -Dan **
//*****************************************************************************


int minHeightShelves(int** books, int booksSize, int* booksColSize, int shelfWidth) {
    /*
    int retnum = 0;
    int currentWidth = 1;
    for(int i = 0; i < booksSize; i++)
    {

        for(int j = 0; j < booksSize; j++)
        {
            if(books[j][0] < books[i][0])
            {
                int temp = books[j][0];
                int temp2 = books[j][1];
                books[j][0] = books[i][0];
                books[j][1] = books[i][1];
                books[i][0] = temp;
                books[i][1] = temp2;
            }
        }
    }

    int currentShelf = 0;
    int currentHeight = 0;
    int i = 0;
    while(i < booksSize)
    {
        while(currentShelf < shelfWidth)
        {
            if(i >= booksSize) break;
            printf("books[%d] = %d / %d\n",i,books[i][0], books[i][1]);
            currentShelf = books[i][0] + currentShelf;
            if(currentHeight < books[i][1])
            {
                currentHeight = books[i][1];
            }
            i++;
        }
        retnum = retnum + currentHeight;
        currentHeight = 0;
        currentShelf = 0;
        printf("New Shelf\n");
    }
    return retnum;
*/

    int dp[booksSize + 1];
    dp[0] = 0;  // Base case: no books, no height.
    
    for (int i = 1; i <= booksSize; ++i) {
        int width = 0, height = 0;
        dp[i] = INT_MAX;
        for (int j = i; j > 0; --j) {
            width += books[j - 1][0];
            if (width > shelfWidth) break;
            height = (height > books[j - 1][1]) ? height : books[j - 1][1];
            dp[i] = (dp[i] < dp[j - 1] + height) ? dp[i] : (dp[j - 1] + height);
        }
    }
    return dp[booksSize];
}