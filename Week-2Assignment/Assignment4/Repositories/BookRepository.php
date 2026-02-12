class BookRepository
{
    function Save(Book $book)
    {
        $filename = '/documents/'. $book->getTitle(). ' - '. $book->getAuthor();
        file_put_contents($filename, serialize($book));
    }
}