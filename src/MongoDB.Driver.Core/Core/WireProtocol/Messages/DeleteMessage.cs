﻿/* Copyright 2013-2014 MongoDB Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/


using MongoDB.Bson;
using MongoDB.Driver.Core.Misc;
using MongoDB.Driver.Core.WireProtocol.Messages.Encoders;

namespace MongoDB.Driver.Core.WireProtocol.Messages
{
    public class DeleteMessage : RequestMessage, IEncodableMessage<DeleteMessage>
    {
        // fields
        private readonly CollectionNamespace _collectionNamespace;
        private readonly bool _isMulti;
        private readonly BsonDocument _query;

        // constructors
        public DeleteMessage(
            int requestId,
            CollectionNamespace collectionNamespace,
            BsonDocument query,
            bool isMulti)
            : base(requestId)
        {
            _collectionNamespace = Ensure.IsNotNull(collectionNamespace, "collectionNamespace");
            _query = Ensure.IsNotNull(query, "query");
            _isMulti = isMulti;
        }

        // properties
        public CollectionNamespace CollectionNamespace
        {
            get { return _collectionNamespace; }
        }

        public bool IsMulti
        {
            get { return _isMulti; }
        }

        public BsonDocument Query
        {
            get { return _query; }
        }

        // methods
        public new IMessageEncoder<DeleteMessage> GetEncoder(IMessageEncoderFactory encoderFactory)
        {
            return encoderFactory.GetDeleteMessageEncoder();
        }

        protected override IMessageEncoder GetNonGenericEncoder(IMessageEncoderFactory encoderFactory)
        {
            return GetEncoder(encoderFactory);
        }
    }
}
