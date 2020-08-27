// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.ResourceManager.CosmosDB.Models
{
    /// <summary> Cosmos DB SQL storedProcedure resource object. </summary>
    public partial class SqlStoredProcedureResource
    {
        /// <summary> Initializes a new instance of SqlStoredProcedureResource. </summary>
        /// <param name="id"> Name of the Cosmos DB SQL storedProcedure. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        public SqlStoredProcedureResource(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            Id = id;
        }

        /// <summary> Initializes a new instance of SqlStoredProcedureResource. </summary>
        /// <param name="id"> Name of the Cosmos DB SQL storedProcedure. </param>
        /// <param name="body"> Body of the Stored Procedure. </param>
        internal SqlStoredProcedureResource(string id, string body)
        {
            Id = id;
            Body = body;
        }

        /// <summary> Name of the Cosmos DB SQL storedProcedure. </summary>
        public string Id { get; set; }
        /// <summary> Body of the Stored Procedure. </summary>
        public string Body { get; set; }
    }
}