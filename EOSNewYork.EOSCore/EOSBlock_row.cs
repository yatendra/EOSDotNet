﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EOSNewYork.EOSCore.Serialization;
using Newtonsoft.Json;

namespace EOSNewYork.EOSCore
{
    public class EOSBlock_row : IEOAPI
    {
        public string timestamp { get; set; }
        public string producer { get; set; }
        public int confirmed { get; set; }
        public string previous { get; set; }
        public string transaction_mroot { get; set; }
        public string action_mroot { get; set; }
        public int schedule_version { get; set; }
        public string producer_signature { get; set; }
        public List<EOSTransaction> transactions { get; set; }
        public string id { get; set; }
        public long block_num { get; set; }
        public long ref_block_prefix { get; set; }
        public EOSAPIMetadata getMetadata()
        {
            var meta = new EOSAPIMetadata
            {
                uri = "/v1/chain/get_block"
            };

            return meta;
        }

        public class postData
        {
            public string block_num_or_id { get; set; }
        }
    }
    public class EOSTransaction
    {
        public string status { get; set; }
        public int cpu_usage_us { get; set; }
        public int net_usage_words { get; set; }
        public EOSTrx trx { get; set; }
        
    }
    public class EOSTrx
    {
        public string id { get; set; }
        public List<string> signatures { get; set; }
        public string compression { get; set; }
        public string packed_context_free_data { get; set; }
        public List<string> context_free_data{ get; set; }
        public string packed_trx { get; set; }
        public EOSTransactionInner transaction { get; set; }
    }
    public class EOSTransactionInner
    {
        public string expiration { get; set; }
        public long ref_block_num { get; set; }
        public long ref_block_prefix { get; set; }
        public int max_net_usage_words { get; set; }
        public int max_cpu_usage_ms { get; set; }
        public int delay_sec { get; set; }
        public List<EOSAction> context_free_actions { get; set; }
        public List<EOSAction> actions { get; set; }
    }
    public class EOSAuthorization
    {
        public string actor { get; set; }
        public string permission { get; set; }
    }
    public class EOSAction
    {
        public string account { get; set; }
        public string name { get; set; }
        public List<EOSAuthorization> authorization { get; set; }
        [JsonConverter(typeof(JsonStringConverter))]
        public string data { get; set; }
        public string hex_data { get; set; }
    }
}