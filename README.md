# Technologies used in the Project
  **- Elasticsearch : NEST Library and Elasticsearch Cloud.**
  
  **- OOP.**
  
  **- Controller Based Web Api.**
  
# Project Capabilities
  **- CRUD Operation.**
  
  **- Aggregation and Query searches.**

  # Controllers :
  ### AggregationController Methods :
  **- AnnualSales :**  Made from **DateHistogram_CalendarInterval**(**Bucket Agg**) and **Sum(Metric Agg)** Aggregarions.
  
  **- CustomMonthlySalesRange :**  It shows the monthly sales in the specified range. Made from a **Query(DateRange)** and two **Aggregations(DateHistogram and Sum)**.
  
  **- CustomSalesSegmentation :**  It divides the documents according to the specified sales amount and also shows the **average** sales. Made from **Histogram** and **Average** Aggrigations.
  
  **- CustomSalesSegmentationRange :**  It divides the documents according to the specified **Range**(**to** | **from_to** | **from**). Made from **Range** Aggrigations.

  **- TermAggregation :**  It will run **Term** aggregation to specified **Field**(_type of field must be keyword_).


   ### QueryController Methods :
  **- Match :** **match** query o[ElasticsearchDocumentation.zip](https://github.com/MahdiChoobin-81/ElasticsearchDemo/files/14321878/ElasticsearchDocumentation.zip)
n _product_name_ field.
  
  **- MultiMatch :**  **multi_match** query on _product_name_ and _customer_name_ fields.

  **- MultiAndPhraseMatch :**  **match_phrase** and **multi_match** query on _product_name_ and _customer_name_ field.
  
  **- BoolQueryMultiMatch :** **bool** query with Must(multi_match), MustNot(multi_match), Should(multi_match) and Filter(date_range).
  
  **- BoolQueryMultiMatchRange :** **bool** query with Must(range query on _sales_ field), MustNot(multi_match), Should(multi_match) and Filter(date_range).


   ### CrudController Methods :
   **- GetAllDocuments**
   
   **- CreateOrder**
   
   **- GetOrder** : by Id.
   
   **- UpdateOrder**
   
   **- DeleteOrder**

  










  
