﻿using System;
using System.Collections.Generic;

namespace TNDStudios.Data.DocumentCache
{
    public interface IDocumentHandler<T>
    {
        /// <summary>
        /// Public view of the currently connection
        /// </summary>
        string ConnectionString { get; }

        /// <summary>
        /// Database Name for the cache
        /// </summary>
        string DatabaseName { get; }

        /// <summary>
        /// Collection (table / collection / grouping) for this cache
        /// </summary>
        string DataCollection { get; }

        /// <summary>
        /// Send the object to the cache
        /// </summary>
        /// <typeparam name="T">The data type that is being sent to storage</typeparam>
        /// <param name="id">The value of the new document to be put in storage (as the json has to be case sensitive)</param>
        /// <param name="data">The data to be wrapped up in the cache document</param>
        /// <returns>Success Result</returns>
        Boolean Save(string id, T data);

        /// <summary>
        /// Get the object from the cache by the id reference
        /// </summary>
        /// <param name="id">The id of the document</param>
        /// <returns>The document from the cache</returns>
        T Get(string id);

        /// <summary>
        /// Get all items that are marked a having not been processed yet
        /// </summary>
        /// <returns>A list of unprocessed items</returns>
        List<T> GetToProcess(Int32 maxRecords);

        /// <summary>
        /// Mark a set of documents as processed
        /// </summary>
        /// <param name="documentsToMark">A list of document id's to mark as processed</param>
        /// <returns>The id's of the documents that did get marked</returns>
        List<String> MarkAsProcessed(List<String> documentsToMark);

        /// <summary>
        /// Purge (Delete) all items marked as processed
        /// </summary>
        /// <returns>If the purge was successful</returns>
        Boolean Purge();
    }
}