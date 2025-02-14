﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ArangoDBNetStandard.DocumentApi.Models;
using ArangoDBNetStandard.Serialization;

namespace ArangoDBNetStandard.DocumentApi
{
    /// <summary>
    /// Defines a client to access the ArangoDB Document API.
    /// </summary>
    public interface IDocumentApiClient
    {
        /// <summary>
        /// Post a single document.
        /// </summary>
        /// <typeparam name="T">The type of the post object used to record a new document.</typeparam>
        /// <param name="collectionName"></param>
        /// <param name="document"></param>
        /// <param name="query"></param>
        /// <param name="serializationOptions">The serialization options. When the value is null the
        /// the serialization options should be provided by the serializer, otherwise the given options should be used.</param>
        /// <param name="headers">The <see cref="DocumentHeaderProperties"/> values.</param>
        /// <param name="token">A CancellationToken to observe while waiting for the task to complete or to cancel the task.</param>
        /// <returns></returns>
        Task<PostDocumentResponse<T>> PostDocumentAsync<T>(
           string collectionName,
           T document,
           PostDocumentsQuery query = null,
           ApiClientSerializationOptions serializationOptions = null,
           DocumentHeaderProperties headers = null,
            CancellationToken token = default);

        /// <summary>
        /// Post a single document with the possibility to specify a different type
        /// for the new document object returned in the response.
        /// </summary>
        /// <typeparam name="T">The type of the post object used to record a new document.</typeparam>
        /// <typeparam name="U">Type of the returned document, only applies when
        /// <see cref="PostDocumentsQuery.ReturnNew"/> or <see cref="PostDocumentsQuery.ReturnOld"/>
        /// are used.</typeparam>
        /// <param name="collectionName"></param>
        /// <param name="document"></param>
        /// <param name="query"></param>
        /// <param name="serializationOptions">The serialization options. When the value is null the
        /// the serialization options should be provided by the serializer, otherwise the given options should be used.</param>
        /// <param name="headers">The <see cref="DocumentHeaderProperties"/> values.</param>
        /// <param name="token">A CancellationToken to observe while waiting for the task to complete or to cancel the task.</param>
        /// <returns></returns>
        Task<PostDocumentResponse<U>> PostDocumentAsync<T, U>(
           string collectionName,
           T document,
           PostDocumentsQuery query = null,
           ApiClientSerializationOptions serializationOptions = null,
           DocumentHeaderProperties headers = null,
            CancellationToken token = default);

        /// <summary>
        /// Post multiple documents in a single request.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="documents"></param>
        /// <param name="query"></param>
        /// <param name="serializationOptions">The serialization options. When the value is null the
        /// the serialization options should be provided by the serializer, otherwise the given options should be used.</param>
        /// <param name="headers">The <see cref="DocumentHeaderProperties"/> values.</param>
        /// <param name="token">A CancellationToken to observe while waiting for the task to complete or to cancel the task.</param>
        /// <returns></returns>
        Task<PostDocumentsResponse<T>> PostDocumentsAsync<T>(
           string collectionName,
           IList<T> documents,
           PostDocumentsQuery query = null,
           ApiClientSerializationOptions serializationOptions = null,
           DocumentHeaderProperties headers = null,
            CancellationToken token = default);

        /// <summary>
        /// Replace multiple documents.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="documents"></param>
        /// <param name="query"></param>
        /// <param name="serializationOptions">The serialization options. When the value is null the
        /// the serialization options should be provided by the serializer, otherwise the given options should be used.</param>
        /// <param name="headers">The <see cref="DocumentHeaderProperties"/> values.</param>
        /// <param name="token">A CancellationToken to observe while waiting for the task to complete or to cancel the task.</param>
        /// <returns></returns>
        Task<PutDocumentsResponse<T>> PutDocumentsAsync<T>(
           string collectionName,
           IList<T> documents,
           PutDocumentsQuery query = null,
           ApiClientSerializationOptions serializationOptions = null,
           DocumentHeaderProperties headers = null,
            CancellationToken token = default);

        /// <summary>
        /// Replaces the document with the provided document ID with the one in
        /// the body, provided there is such a document and no precondition is
        /// violated.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="documentId"></param>
        /// <param name="doc"></param>
        /// <param name="opts"></param>
        /// <param name="serializationOptions">The serialization options. When the value is null the
        /// the serialization options should be provided by the serializer, otherwise the given options should be used.</param>
        /// <param name="headers">The <see cref="DocumentHeaderProperties"/> values.</param>
        /// <param name="token">A CancellationToken to observe while waiting for the task to complete or to cancel the task.</param>
        /// <returns></returns>
        Task<PutDocumentResponse<T>> PutDocumentAsync<T>(
            string documentId,
            T doc,
            PutDocumentQuery opts = null,
            ApiClientSerializationOptions serializationOptions = null,
            DocumentHeaderProperties headers = null,
            CancellationToken token = default);

        /// <summary>
        /// Replaces the document based on its Document ID with the one in
        /// the body, provided there is such a document and no precondition is
        /// violated.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="documentKey"></param>
        /// <param name="doc"></param>
        /// <param name="opts"></param>
        /// <param name="headers">The <see cref="DocumentHeaderProperties"/> values.</param>
        /// <param name="token">A CancellationToken to observe while waiting for the task to complete or to cancel the task.</param>
        /// <returns></returns>
        Task<PutDocumentResponse<T>> PutDocumentAsync<T>(
            string collectionName,
            string documentKey,
            T doc,
            PutDocumentQuery opts = null,
            DocumentHeaderProperties headers = null,
            CancellationToken token = default);

        /// <summary>
        /// Get an existing document.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="documentKey"></param>
        /// <param name="headers">The <see cref="DocumentHeaderProperties"/> values.</param>
        /// <param name="token">A CancellationToken to observe while waiting for the task to complete or to cancel the task.</param>
        /// <returns></returns>
        Task<T> GetDocumentAsync<T>(string collectionName, string documentKey, DocumentHeaderProperties headers = null,
            CancellationToken token = default);

        /// <summary>
        /// Get an existing document based on its Document ID.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="documentId"></param>
        /// <param name="headers">The <see cref="DocumentHeaderProperties"/> values.</param>
        /// <param name="token">A CancellationToken to observe while waiting for the task to complete or to cancel the task.</param>
        /// <returns></returns>
        Task<T> GetDocumentAsync<T>(string documentId, DocumentHeaderProperties headers = null,
            CancellationToken token = default);

        /// <summary>
        /// Get multiple documents.
        /// </summary>
        /// <typeparam name="T">The type of the documents
        /// deserialized from the response.</typeparam>
        /// <param name="collectionName">Collection name</param>
        /// <param name="selectors">Document keys to fetch documents for</param>
        /// <param name="headers">The <see cref="DocumentHeaderProperties"/> values.</param>
        /// <param name="token">A CancellationToken to observe while waiting for the task to complete or to cancel the task.</param>
        /// <returns></returns>
        Task<List<T>> GetDocumentsAsync<T>(
            string collectionName,
            IList<string> selectors,
            DocumentHeaderProperties headers = null,
            CancellationToken token = default);

        /// <summary>
        /// Delete a document.
        /// </summary>
        /// <remarks>
        /// This method overload is provided as a convenience when the client does not care about the type of <see cref="DeleteDocumentResponse{T}.Old"/>
        /// in the returned <see cref="DeleteDocumentResponse{T}"/>. Its value will be <c>null</c> when 
        /// <see cref="DeleteDocumentQuery.ReturnOld"/> is either <c>false</c> or not set, so this overload is useful in the default case 
        /// when deleting documents.
        /// </remarks>
        /// <param name="collectionName"></param>
        /// <param name="documentKey"></param>
        /// <param name="query"></param>
        /// <param name="headers">The <see cref="DocumentHeaderProperties"/> values.</param>
        /// <param name="token">A CancellationToken to observe while waiting for the task to complete or to cancel the task.</param>
        /// <returns></returns>
        Task<DeleteDocumentResponse<object>> DeleteDocumentAsync(
            string collectionName,
            string documentKey,
            DeleteDocumentQuery query = null,
            DocumentHeaderProperties headers = null,
            CancellationToken token = default);

        /// <summary>
        /// Delete a document based on its document ID.
        /// </summary>
        /// <remarks>
        /// This method overload is provided as a convenience when the client does not care about the type of <see cref="DeleteDocumentResponse{T}.Old"/>
        /// in the returned <see cref="DeleteDocumentResponse{T}"/>. Its value will be <c>null</c> when 
        /// <see cref="DeleteDocumentQuery.ReturnOld"/> is either <c>false</c> or not set, so this overload is useful in the default case 
        /// when deleting documents.
        /// </remarks>
        /// <param name="documentId"></param>
        /// <param name="query"></param>
        /// <param name="headers">The <see cref="DocumentHeaderProperties"/> values.</param>
        /// <param name="token">A CancellationToken to observe while waiting for the task to complete or to cancel the task.</param>
        /// <returns></returns>
        Task<DeleteDocumentResponse<object>> DeleteDocumentAsync(
            string documentId,
            DeleteDocumentQuery query = null,
            DocumentHeaderProperties headers = null,
            CancellationToken token = default);

        /// <summary>
        /// Delete a document.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="documentKey"></param>
        /// <param name="query"></param>
        /// <param name="headers">The <see cref="DocumentHeaderProperties"/> values.</param>
        /// <param name="token">A CancellationToken to observe while waiting for the task to complete or to cancel the task.</param>
        /// <returns></returns>
        Task<DeleteDocumentResponse<T>> DeleteDocumentAsync<T>(
          string collectionName,
          string documentKey,
          DeleteDocumentQuery query = null,
          DocumentHeaderProperties headers = null,
            CancellationToken token = default);

        /// <summary>
        /// Delete a document based on its document ID.
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="query"></param>
        /// <param name="headers">The <see cref="DocumentHeaderProperties"/> values.</param>
        /// <param name="token">A CancellationToken to observe while waiting for the task to complete or to cancel the task.</param>
        /// <returns></returns>
        Task<DeleteDocumentResponse<T>> DeleteDocumentAsync<T>(
          string documentId,
          DeleteDocumentQuery query = null,
          DocumentHeaderProperties headers = null,
            CancellationToken token = default);

        /// <summary>
        /// Delete multiple documents based on the passed document selectors.
        /// A document selector is either the document ID or the document Key.
        /// </summary>
        /// <remarks>
        /// This method overload is provided as a convenience when the client does not care about the type of <see cref="DeleteDocumentResponse{T}.Old"/>
        /// in the returned <see cref="DeleteDocumentsResponse{T}"/>. These will be <c>null</c> when 
        /// <see cref="DeleteDocumentsQuery.ReturnOld"/> is either <c>false</c> or not set, so this overload is useful in the default case 
        /// when deleting documents.
        /// </remarks>
        /// <param name="collectionName"></param>
        /// <param name="selectors"></param>
        /// <param name="query"></param>
        /// <param name="headers">The <see cref="DocumentHeaderProperties"/> values.</param>
        /// <param name="token">A CancellationToken to observe while waiting for the task to complete or to cancel the task.</param>
        /// <returns></returns>
        Task<DeleteDocumentsResponse<object>> DeleteDocumentsAsync(
          string collectionName,
          IList<string> selectors,
          DeleteDocumentsQuery query = null,
          DocumentHeaderProperties headers = null,
            CancellationToken token = default);

        /// <summary>
        /// Delete multiple documents based on the passed document selectors.
        /// A document selector is either the document ID or the document Key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="selectors"></param>
        /// <param name="query"></param>
        /// <param name="headers">The <see cref="DocumentHeaderProperties"/> values.</param>
        /// <param name="token">A CancellationToken to observe while waiting for the task to complete or to cancel the task.</param>
        /// <returns></returns>
        Task<DeleteDocumentsResponse<T>> DeleteDocumentsAsync<T>(
          string collectionName,
          IList<string> selectors,
          DeleteDocumentsQuery query = null,
          DocumentHeaderProperties headers = null,
            CancellationToken token = default);

        /// <summary>
        /// Partially updates documents, the documents to update are specified
        /// by the _key attributes in the body objects.The body of the
        /// request must contain a JSON array of document updates with the
        /// attributes to patch(the patch documents). All attributes from the
        /// patch documents will be added to the existing documents if they do
        /// not yet exist, and overwritten in the existing documents if they do
        /// exist there.
        /// Setting an attribute value to null in the patch documents will cause a
        /// value of null to be saved for the attribute by default.
        /// If ignoreRevs is false and there is a _rev attribute in a
        /// document in the body and its value does not match the revision of
        /// the corresponding document in the database, the precondition is
        /// violated.
        /// PATCH/_api/document/{collection}
        /// </summary>
        /// <typeparam name="T">Type of the patch object used to partially update documents.</typeparam>
        /// <typeparam name="U">Type of the returned documents, only applies when
        /// <see cref="PatchDocumentsQuery.ReturnNew"/> or <see cref="PatchDocumentsQuery.ReturnOld"/>
        /// are used.</typeparam>
        /// <param name="collectionName"></param>
        /// <param name="patches"></param>
        /// <param name="query"></param>
        /// <param name="serializationOptions">The serialization options. When the value is null the
        /// the serialization options should be provided by the serializer, otherwise the given options should be used.</param>
        /// <param name="headers">The <see cref="DocumentHeaderProperties"/> values.</param>
        /// <param name="token">A CancellationToken to observe while waiting for the task to complete or to cancel the task.</param>
        /// <returns></returns>
        Task<PatchDocumentsResponse<U>> PatchDocumentsAsync<T, U>(
          string collectionName,
          IList<T> patches,
          PatchDocumentsQuery query = null,
          ApiClientSerializationOptions serializationOptions = null,
          DocumentHeaderProperties headers = null,
            CancellationToken token = default);

        /// <summary>
        /// Partially updates documents, the documents to update are specified
        /// by the _key attributes in the body objects.The body of the
        /// request must contain a JSON array of document updates with the
        /// attributes to patch(the patch documents). All attributes from the
        /// patch documents will be added to the existing documents if they do
        /// not yet exist, and overwritten in the existing documents if they do
        /// exist there.
        /// Setting an attribute value to null in the patch documents will cause a
        /// value of null to be saved for the attribute by default.
        /// If ignoreRevs is false and there is a _rev attribute in a
        /// document in the body and its value does not match the revision of
        /// the corresponding document in the database, the precondition is
        /// violated.
        /// PATCH/_api/document/{collection}
        /// </summary>
        /// <typeparam name="T">Type of the patch object used to partially update documents.
        /// <see cref="PatchDocumentsQuery.ReturnNew"/> or <see cref="PatchDocumentsQuery.ReturnOld"/>
        /// are used.</typeparam>
        /// <param name="collectionName"></param>
        /// <param name="patches"></param>
        /// <param name="query"></param>
        /// <param name="serializationOptions">The serialization options. When the value is null the
        /// the serialization options should be provided by the serializer, otherwise the given options should be used.</param>
        /// <param name="headers">The <see cref="DocumentHeaderProperties"/> values.</param>
        /// <param name="token">A CancellationToken to observe while waiting for the task to complete or to cancel the task.</param>
        /// <returns></returns>
        Task<PatchDocumentsResponse<object>> PatchDocumentsAsync<T>(
          string collectionName,
          IList<T> patches,
          PatchDocumentsQuery query = null,
          ApiClientSerializationOptions serializationOptions = null,
          DocumentHeaderProperties headers = null,
            CancellationToken token = default);

        /// <summary>
        /// Partially updates the document identified by document-handle.
        /// The body of the request must contain a JSON document with the
        /// attributes to patch(the patch document). All attributes from the
        /// patch document will be added to the existing document if they do not
        /// yet exist, and overwritten in the existing document if they do exist
        /// there.
        /// PATCH/_api/document/{document-handle}
        /// </summary>
        /// <typeparam name="T">Type of the patch object used to partially update a document.</typeparam>
        /// <typeparam name="U">Type of the returned document, only applies when
        /// <see cref="PatchDocumentQuery.ReturnNew"/> or <see cref="PatchDocumentQuery.ReturnOld"/>
        /// are used.</typeparam>
        /// <param name="collectionName"></param>
        /// <param name="documentKey"></param>
        /// <param name="body"></param>
        /// <param name="query"></param>
        /// <param name="headers">The <see cref="DocumentHeaderProperties"/> values.</param>
        /// <param name="token">A CancellationToken to observe while waiting for the task to complete or to cancel the task.</param>
        /// <returns></returns>
        Task<PatchDocumentResponse<U>> PatchDocumentAsync<T, U>(
          string collectionName,
          string documentKey,
          T body,
          PatchDocumentQuery query = null,
          DocumentHeaderProperties headers = null,
            CancellationToken token = default);

        /// <summary>
        /// Partially updates the document identified by document-handle.
        /// The body of the request must contain a JSON document with the
        /// attributes to patch(the patch document). All attributes from the
        /// patch document will be added to the existing document if they do not
        /// yet exist, and overwritten in the existing document if they do exist
        /// there.
        /// PATCH/_api/document/{document-handle}
        /// </summary>
        /// <typeparam name="T">Type of the patch object used to partially update a document.</typeparam>
        /// <typeparam name="U">Type of the returned document, only applies when
        /// <see cref="PatchDocumentQuery.ReturnNew"/> or <see cref="PatchDocumentQuery.ReturnOld"/>
        /// are used.</typeparam>
        /// <param name="documentId"></param>
        /// <param name="body"></param>
        /// <param name="query"></param>
        /// <param name="serializationOptions">The serialization options. When the value is null the
        /// the serialization options should be provided by the serializer, otherwise the given options should be used.</param>
        /// <param name="headers">The <see cref="DocumentHeaderProperties"/> values.</param>
        /// <param name="token">A CancellationToken to observe while waiting for the task to complete or to cancel the task.</param>
        /// <returns></returns>
        Task<PatchDocumentResponse<U>> PatchDocumentAsync<T, U>(
          string documentId,
          T body,
          PatchDocumentQuery query = null,
          ApiClientSerializationOptions serializationOptions = null,
          DocumentHeaderProperties headers = null,
            CancellationToken token = default);

        /// <summary>
        /// Partially updates the document identified by document-handle.
        /// The body of the request must contain a JSON document with the
        /// attributes to patch(the patch document). All attributes from the
        /// patch document will be added to the existing document if they do not
        /// yet exist, and overwritten in the existing document if they do exist
        /// there.
        /// PATCH/_api/document/{document-handle}
        /// </summary>
        /// <typeparam name="T">Type of the patch object used to partially update a document.
        /// <see cref="PatchDocumentQuery.ReturnNew"/> or <see cref="PatchDocumentQuery.ReturnOld"/>
        /// are used.</typeparam>
        /// <param name="documentId"></param>
        /// <param name="body"></param>
        /// <param name="query"></param>
        /// <param name="token">A CancellationToken to observe while waiting for the task to complete or to cancel the task.</param>
        /// <returns></returns>
        Task<PatchDocumentResponse<object>> PatchDocumentAsync<T>(
            string documentId,
            T body,
            PatchDocumentQuery query = null,
            CancellationToken token = default);

        /// <summary>
        /// Like GET, but only returns the header fields and not the body. You
        /// can use this call to get the current revision of a document or check if
        /// the document was deleted.
        /// HEAD /_api/document/{document-handle}
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="documentKey"></param>
        /// <param name="headers">The <see cref="DocumentHeaderProperties"/> values.</param>
        /// <param name="token">A CancellationToken to observe while waiting for the task to complete or to cancel the task.</param>
        /// <remarks>
        /// 200: is returned if the document was found. 
        /// 304: is returned if the “If-None-Match” header is given and the document has the same version. 
        /// 400: is returned if the "TransactionId" header is given and the transactionId does not exist.
        /// 404: is returned if the document or collection was not found. 
        /// 412: is returned if an “If-Match” header is given and the found document has a different version. The response will also contain the found document’s current revision in the Etag header.
        /// </remarks>
        /// <returns></returns>
        Task<HeadDocumentResponse> HeadDocumentAsync(
          string collectionName,
          string documentKey,
          DocumentHeaderProperties headers = null,
            CancellationToken token = default);

        /// <summary>
        /// Like GET, but only returns the header fields and not the body. You
        /// can use this call to get the current revision of a document or check if
        /// the document was deleted.
        /// HEAD/_api/document/{document-handle}
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="headers">The <see cref="DocumentHeaderProperties"/> values.</param>
        /// <param name="token">A CancellationToken to observe while waiting for the task to complete or to cancel the task.</param>
        /// <exception cref="ArgumentException">Document ID is invalid.</exception>
        /// <remarks>
        /// 200: is returned if the document was found. 
        /// 304: is returned if the “If-None-Match” header is given and the document has the same version. 
        /// 400: is returned if the "TransactionId" header is given and the transactionId does not exist.
        /// 404: is returned if the document or collection was not found. 
        /// 412: is returned if an “If-Match” header is given and the found document has a different version. The response will also contain the found document’s current revision in the Etag header.
        /// </remarks>
        /// <returns></returns>
        Task<HeadDocumentResponse> HeadDocumentAsync(string documentId, 
            DocumentHeaderProperties headers = null,
            CancellationToken token = default);
    }
}
