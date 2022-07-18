# product-catalog
The product catalog implementation is using default 'Array.Sort' and 'Array.BinarySearch'. The reason for that is it's impossible to write faster versions of them because they were written with maximum efficiency. So, this solution is good enough. Of course, in case of high load processing of big amounts of data on a client (which is always a bad idea) there might be a situation in which we would like to speed up sorting and filtering. And here is a room for differing optimisations:
1. Cashing (for sorting / filtering in constructor).
2. Use more suitable data structure instead of array.
3. Which could lead to custom Sort and BinarySearch.
Writing a special (faster) version of ProductCatalog only for structs. It opens doors for using Span, NativeCollections, e.t.c.

Example: https://github.com/AGeorgy/product-catalog-example
