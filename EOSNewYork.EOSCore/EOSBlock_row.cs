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
        public DateTime timestamp_datetime
        {
            get
            {
                return DateTime.SpecifyKind((DateTime.Parse(timestamp)), DateTimeKind.Utc);
            }
        }
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
        public DateTime expiration_datetime
        {
            get
            {
                return DateTime.SpecifyKind((DateTime.Parse(expiration)), DateTimeKind.Utc);
            }
        }
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
    public class EOSActionData
    {
        public string creator { get; set; }
        public string name { get; set; }
        public EOSRole owner { get; set; }
        public EOSRole active { get; set; }
    }
    public class EOSRole
    {
        public int threshold { get; set; }
        public List<EOSKey> keys { get; set; }
        public List<string> accounts { get; set; }
        public List<string> waits { get; set; }
    }
    public class EOSKey
    {
        public string key { get; set; }
        public int weight { get; set; }
    }
}
/*
{"timestamp":"2018-06-09T00:56:30.500","producer":"eosio","confirmed":0,"previous":"0000006326e9cf1bb3ec0a566afa19e69d4ed726f4728149d89a536010420f1a","transaction_mroot":"c428af6032a515f46b0e863a0a9d5939901d7eb7fd17696b47e47c2390e4ca08","action_mroot":"299db91c63bce0c5e00eff2a9dccad4343949ab678dacbd5c654329333d6f524","schedule_version":0,"new_producers":null,"header_extensions":[],"producer_signature":"SIG_K1_KbyRkAmUvs5kC4L3B2YZS7spgfRxRGX68rRnzYkzUq6aDzsci7ZyWFffMCfxpXvz91rVWsBXJXaJ1WMC2VDBDPwe4ZADtc","transactions":[{"status":"executed","cpu_usage_us":7697,"net_usage_words":45,"trx":{"id":"2cf80fbf0f374a5ccd2621060ce4a36f009e8a9677f821d58b1489d167612c11","signatures":["SIG_K1_KB6qz2PN8pwuY4nx8RVYMTh8V54yQaTUAtWPHtJaUUacjdpEcVADcKyaE2MwEe51LSdL3fPWdMNKHGx9rPeKsE6bydEv9w"],"compression":"none","packed_context_free_data":"","context_free_data":[],"packed_trx":"86261b5b6200da3412260000000100408c7a02ea3055000000000085269d000822d9a6fc2a6e0500030000000000ea305500409e9a2264b89a010000000000ea305500000000a8ed3232660000000000ea305580d554cc4c96886201000000010003e563eac1e582849edef0bc9fc70fa1a5d5472010affc08cebcc400f77b5d99e90100000001000000010003e563eac1e582849edef0bc9fc70fa1a5d5472010affc08cebcc400f77b5d99e9010000000000000000ea305500b0cafe4873bd3e010000000000ea305500000000a8ed3232140000000000ea305580d554cc4c968862002000000000000000ea305500003f2a1ba6a24a010000000000ea305500000000a8ed3232310000000000ea305580d554cc4c968862881300000000000004454f5300000000881300000000000004454f53000000000100","transaction":{"expiration":"2018-06-09T00:59:50","ref_block_num":98,"ref_block_prefix":638727386,"max_net_usage_words":0,"max_cpu_usage_ms":0,"delay_sec":0,"context_free_actions":[{"account":"eosio.null","name":"nonce","authorization":[],"data":"22d9a6fc2a6e0500"}],"actions":[{"account":"eosio","name":"newaccount","authorization":[{"actor":"eosio","permission":"active"}],"data":{"creator":"eosio","name":"ge4dgnagenes","owner":{"threshold":1,"keys":[{"key":"EOS8aFzoYsveDCx3YHmfM2HitGRAYRU5LcLNeHU64i8sBH8YDTJZ9","weight":1}],"accounts":[],"waits":[]},"active":{"threshold":1,"keys":[{"key":"EOS8aFzoYsveDCx3YHmfM2HitGRAYRU5LcLNeHU64i8sBH8YDTJZ9","weight":1}],"accounts":[],"waits":[]}},"hex_data":"0000000000ea305580d554cc4c96886201000000010003e563eac1e582849edef0bc9fc70fa1a5d5472010affc08cebcc400f77b5d99e90100000001000000010003e563eac1e582849edef0bc9fc70fa1a5d5472010affc08cebcc400f77b5d99e901000000"},{"account":"eosio","name":"buyrambytes","authorization":[{"actor":"eosio","permission":"active"}],"data":{"payer":"eosio","receiver":"ge4dgnagenes","bytes":8192},"hex_data":"0000000000ea305580d554cc4c96886200200000"},{"account":"eosio","name":"delegatebw","authorization":[{"actor":"eosio","permission":"active"}],"data":{"from":"eosio","receiver":"ge4dgnagenes","stake_net_quantity":"0.5000 EOS","stake_cpu_quantity":"0.5000 EOS","transfer":1},"hex_data":"0000000000ea305580d554cc4c968862881300000000000004454f5300000000881300000000000004454f530000000001"}],"transaction_extensions":[]}}},{"status":"executed","cpu_usage_us":1373,"net_usage_words":22,"trx":{"id":"3df73f2fd8bdd11a1aa35a7d6db49c40042c49d0af36307acf0cec9514209c71","signatures":["SIG_K1_JyuQcVTGHMfkpffJXXLCLfTNmLLcFJYRJCY7ksNBUwr7v6FLedXPD23x1jvNrda9THo7PPRXjGvJ3MJVQuUPPGyQEABi9B"],"compression":"none","packed_context_free_data":"","context_free_data":[],"packed_trx":"22261b5b6200da3412260000000100408c7a02ea3055000000000085269d00080e7ba7fc2a6e05000100a6823403ea3055000000572d3ccdcd010000000000ea305500000000a8ed3232380000000000ea305580d554cc4c968862cb5d00000000000004454f5300000000177465737420455243323020446973747269627574696f6e00","transaction":{"expiration":"2018-06-09T00:58:10","ref_block_num":98,"ref_block_prefix":638727386,"max_net_usage_words":0,"max_cpu_usage_ms":0,"delay_sec":0,"context_free_actions":[{"account":"eosio.null","name":"nonce","authorization":[],"data":"0e7ba7fc2a6e0500"}],"actions":[{"account":"eosio.token","name":"transfer","authorization":[{"actor":"eosio","permission":"active"}],"data":{"from":"eosio","to":"ge4dgnagenes","quantity":"2.4011 EOS","memo":"test ERC20 Distribution"},"hex_data":"0000000000ea305580d554cc4c968862cb5d00000000000004454f5300000000177465737420455243323020446973747269627574696f6e"}],"transaction_extensions":[]}}},{"status":"executed","cpu_usage_us":7098,"net_usage_words":45,"trx":{"id":"ca0263774b020cc09da1466d35e3935cd74fb5433874dbe43fb33ea390b14522","signatures":["SIG_K1_Kd7Mp8RbFb8HQNrnnUviV9spQrwKh1jpuYs1dyriGzovJDkWgQ84hC3QwdcYeEiJS2UPpg1SyHhXZYixAYw92hkRaKZhFp"],"compression":"none","packed_context_free_data":"","context_free_data":[],"packed_trx":"86261b5b6200da3412260000000100408c7a02ea3055000000000085269d00081219a8fc2a6e0500030000000000ea305500409e9a2264b89a010000000000ea305500000000a8ed3232660000000000ea305580d554cc4f96886201000000010002fa088da12f63f03554878ccd90d693271f2f4618e5a7eaaec7e67d533df07db90100000001000000010002fa088da12f63f03554878ccd90d693271f2f4618e5a7eaaec7e67d533df07db9010000000000000000ea305500b0cafe4873bd3e010000000000ea305500000000a8ed3232140000000000ea305580d554cc4f968862002000000000000000ea305500003f2a1ba6a24a010000000000ea305500000000a8ed3232310000000000ea305580d554cc4f968862105a37000000000004454f5300000000105a37000000000004454f53000000000100","transaction":{"expiration":"2018-06-09T00:59:50","ref_block_num":98,"ref_block_prefix":638727386,"max_net_usage_words":0,"max_cpu_usage_ms":0,"delay_sec":0,"context_free_actions":[{"account":"eosio.null","name":"nonce","authorization":[],"data":"1219a8fc2a6e0500"}],"actions":[{"account":"eosio","name":"newaccount","authorization":[{"actor":"eosio","permission":"active"}],"data":{"creator":"eosio","name":"ge4dgnygenes","owner":{"threshold":1,"keys":[{"key":"EOS6nc818mPpLgp6xcWFEYrxDomV8wE7yXDQJYoy9rhfLXpcLT4m9","weight":1}],"accounts":[],"waits":[]},"active":{"threshold":1,"keys":[{"key":"EOS6nc818mPpLgp6xcWFEYrxDomV8wE7yXDQJYoy9rhfLXpcLT4m9","weight":1}],"accounts":[],"waits":[]}},"hex_data":"0000000000ea305580d554cc4f96886201000000010002fa088da12f63f03554878ccd90d693271f2f4618e5a7eaaec7e67d533df07db90100000001000000010002fa088da12f63f03554878ccd90d693271f2f4618e5a7eaaec7e67d533df07db901000000"},{"account":"eosio","name":"buyrambytes","authorization":[{"actor":"eosio","permission":"active"}],"data":{"payer":"eosio","receiver":"ge4dgnygenes","bytes":8192},"hex_data":"0000000000ea305580d554cc4f96886200200000"},{"account":"eosio","name":"delegatebw","authorization":[{"actor":"eosio","permission":"active"}],"data":{"from":"eosio","receiver":"ge4dgnygenes","stake_net_quantity":"362.7536 EOS","stake_cpu_quantity":"362.7536 EOS","transfer":1},"hex_data":"0000000000ea305580d554cc4f968862105a37000000000004454f5300000000105a37000000000004454f530000000001"}],"transaction_extensions":[]}}},{"status":"executed","cpu_usage_us":1165,"net_usage_words":22,"trx":{"id":"b9c4cc7e9721a07a8b42bd79ce718fd76eedb1b4c02fbab662baa15f785b4212","signatures":["SIG_K1_KkbJEGYZSv6Tf5L1DvPky8EBrtt9hXX5MTHB5xHrgmwbXonZqhHM2WD4xXvKyzc7QVzHrF6kFnmkgBRiT9EcoUiR8b1Dfe"],"compression":"none","packed_context_free_data":"","context_free_data":[],"packed_trx":"22261b5b6200da3412260000000100408c7a02ea3055000000000085269d000845c5a8fc2a6e05000100a6823403ea3055000000572d3ccdcd010000000000ea305500000000a8ed3232380000000000ea305580d554cc4f968862a08601000000000004454f5300000000177465737420455243323020446973747269627574696f6e00","transaction":{"expiration":"2018-06-09T00:58:10","ref_block_num":98,"ref_block_prefix":638727386,"max_net_usage_words":0,"max_cpu_usage_ms":0,"delay_sec":0,"context_free_actions":[{"account":"eosio.null","name":"nonce","authorization":[],"data":"45c5a8fc2a6e0500"}],"actions":[{"account":"eosio.token","name":"transfer","authorization":[{"actor":"eosio","permission":"active"}],"data":{"from":"eosio","to":"ge4dgnygenes","quantity":"10.0000 EOS","memo":"test ERC20 Distribution"},"hex_data":"0000000000ea305580d554cc4f968862a08601000000000004454f5300000000177465737420455243323020446973747269627574696f6e"}],"transaction_extensions":[]}}},{"status":"executed","cpu_usage_us":7104,"net_usage_words":45,"trx":{"id":"0f3c18790674b59be401bba1018170237f8686e7f28a2a961e28b1523a3a2af9","signatures":["SIG_K1_JyugiEDzLKsbCVAk5vA4p1ENkSyvTqbSfBvsUHr53twyxSrDMCzrNao4S1e9NeN4CvEkB4VJ3CPvqkSYhzp1Dz8ovZJKph"],"compression":"none","packed_context_free_data":"","context_free_data":[],"packed_trx":"86261b5b6200da3412260000000100408c7a02ea3055000000000085269d00085d89a9fc2a6e0500030000000000ea305500409e9a2264b89a010000000000ea305500000000a8ed3232660000000000ea305580d554cc4a99886201000000010002752c55edcc981a3fc1389d103524a21917346acb3da2893b89b57c0abaa471a50100000001000000010002752c55edcc981a3fc1389d103524a21917346acb3da2893b89b57c0abaa471a5010000000000000000ea305500b0cafe4873bd3e010000000000ea305500000000a8ed3232140000000000ea305580d554cc4a998862002000000000000000ea305500003f2a1ba6a24a010000000000ea305500000000a8ed3232310000000000ea305580d554cc4a998862d3db00000000000004454f5300000000d3db00000000000004454f53000000000100","transaction":{"expiration":"2018-06-09T00:59:50","ref_block_num":98,"ref_block_prefix":638727386,"max_net_usage_words":0,"max_cpu_usage_ms":0,"delay_sec":0,"context_free_actions":[{"account":"eosio.null","name":"nonce","authorization":[],"data":"5d89a9fc2a6e0500"}],"actions":[{"account":"eosio","name":"newaccount","authorization":[{"actor":"eosio","permission":"active"}],"data":{"creator":"eosio","name":"ge4dmmqgenes","owner":{"threshold":1,"keys":[{"key":"EOS5n6PJoGoaTBFUhyW9FEvwrfRWB2p29jrj6FP9sobjwVxkV5pz9","weight":1}],"accounts":[],"waits":[]},"active":{"threshold":1,"keys":[{"key":"EOS5n6PJoGoaTBFUhyW9FEvwrfRWB2p29jrj6FP9sobjwVxkV5pz9","weight":1}],"accounts":[],"waits":[]}},"hex_data":"0000000000ea305580d554cc4a99886201000000010002752c55edcc981a3fc1389d103524a21917346acb3da2893b89b57c0abaa471a50100000001000000010002752c55edcc981a3fc1389d103524a21917346acb3da2893b89b57c0abaa471a501000000"},{"account":"eosio","name":"buyrambytes","authorization":[{"actor":"eosio","permission":"active"}],"data":{"payer":"eosio","receiver":"ge4dmmqgenes","bytes":8192},"hex_data":"0000000000ea305580d554cc4a99886200200000"},{"account":"eosio","name":"delegatebw","authorization":[{"actor":"eosio","permission":"active"}],"data":{"from":"eosio","receiver":"ge4dmmqgenes","stake_net_quantity":"5.6275 EOS","stake_cpu_quantity":"5.6275 EOS","transfer":1},"hex_data":"0000000000ea305580d554cc4a998862d3db00000000000004454f5300000000d3db00000000000004454f530000000001"}],"transaction_extensions":[]}}},{"status":"executed","cpu_usage_us":1135,"net_usage_words":22,"trx":{"id":"95ab21e774bd8782b5d8c17d9e7cee31896640c01b02d9547aa3f5cb15ee473a","signatures":["SIG_K1_K84RdExQed4nQV1qJvxS8P26yPL3eDQs8e5fRPmxFfpu2s8HPSEsyGJyApid2vsPcseQxdhfC2d4X2Hu1WUQ1GAhKmyJwc"],"compression":"none","packed_context_free_data":"","context_free_data":[],"packed_trx":"22261b5b6200da3412260000000100408c7a02ea3055000000000085269d00084341aafc2a6e05000100a6823403ea3055000000572d3ccdcd010000000000ea305500000000a8ed3232380000000000ea305580d554cc4a998862a08601000000000004454f5300000000177465737420455243323020446973747269627574696f6e00","transaction":{"expiration":"2018-06-09T00:58:10","ref_block_num":98,"ref_block_prefix":638727386,"max_net_usage_words":0,"max_cpu_usage_ms":0,"delay_sec":0,"context_free_actions":[{"account":"eosio.null","name":"nonce","authorization":[],"data":"4341aafc2a6e0500"}],"actions":[{"account":"eosio.token","name":"transfer","authorization":[{"actor":"eosio","permission":"active"}],"data":{"from":"eosio","to":"ge4dmmqgenes","quantity":"10.0000 EOS","memo":"test ERC20 Distribution"},"hex_data":"0000000000ea305580d554cc4a998862a08601000000000004454f5300000000177465737420455243323020446973747269627574696f6e"}],"transaction_extensions":[]}}},{"status":"executed","cpu_usage_us":7461,"net_usage_words":45,"trx":{"id":"802fcdb674831ad2945c950d57d1982ed9f73b882c228dc37f8fb5e8ae8f1bca","signatures":["SIG_K1_KehdbF9vgdfBmRXuAtMJMNDT8FftxrCeMh4VPL1nvNLLs5UrHorWqJNhPrUH4SaZCmTidKdeqJH6BkduCw3HmJhMQxtxVW"],"compression":"none","packed_context_free_data":"","context_free_data":[],"packed_trx":"86261b5b6200da3412260000000100408c7a02ea3055000000000085269d0008e1f1aafc2a6e0500030000000000ea305500409e9a2264b89a010000000000ea305500000000a8ed3232660000000000ea305580d554cc4b9988620100000001000343d4d7757ed215119019f77adb8cc563c3db3e67257326294cd33af2f9cf1bc5010000000100000001000343d4d7757ed215119019f77adb8cc563c3db3e67257326294cd33af2f9cf1bc5010000000000000000ea305500b0cafe4873bd3e010000000000ea305500000000a8ed3232140000000000ea305580d554cc4b998862002000000000000000ea305500003f2a1ba6a24a010000000000ea305500000000a8ed3232310000000000ea305580d554cc4b998862881300000000000004454f5300000000881300000000000004454f53000000000100","transaction":{"expiration":"2018-06-09T00:59:50","ref_block_num":98,"ref_block_prefix":638727386,"max_net_usage_words":0,"max_cpu_usage_ms":0,"delay_sec":0,"context_free_actions":[{"account":"eosio.null","name":"nonce","authorization":[],"data":"e1f1aafc2a6e0500"}],"actions":[{"account":"eosio","name":"newaccount","authorization":[{"actor":"eosio","permission":"active"}],"data":{"creator":"eosio","name":"ge4dmmygenes","owner":{"threshold":1,"keys":[{"key":"EOS7M7C7ecnweXnPihsJB3hodYnrbhu2adAo8fA6jnYCRCgzpYCuE","weight":1}],"accounts":[],"waits":[]},"active":{"threshold":1,"keys":[{"key":"EOS7M7C7ecnweXnPihsJB3hodYnrbhu2adAo8fA6jnYCRCgzpYCuE","weight":1}],"accounts":[],"waits":[]}},"hex_data":"0000000000ea305580d554cc4b9988620100000001000343d4d7757ed215119019f77adb8cc563c3db3e67257326294cd33af2f9cf1bc5010000000100000001000343d4d7757ed215119019f77adb8cc563c3db3e67257326294cd33af2f9cf1bc501000000"},{"account":"eosio","name":"buyrambytes","authorization":[{"actor":"eosio","permission":"active"}],"data":{"payer":"eosio","receiver":"ge4dmmygenes","bytes":8192},"hex_data":"0000000000ea305580d554cc4b99886200200000"},{"account":"eosio","name":"delegatebw","authorization":[{"actor":"eosio","permission":"active"}],"data":{"from":"eosio","receiver":"ge4dmmygenes","stake_net_quantity":"0.5000 EOS","stake_cpu_quantity":"0.5000 EOS","transfer":1},"hex_data":"0000000000ea305580d554cc4b998862881300000000000004454f5300000000881300000000000004454f530000000001"}],"transaction_extensions":[]}}},{"status":"executed","cpu_usage_us":1159,"net_usage_words":22,"trx":{"id":"25fec93ebd807dd439bdd51bf2e25ab7dc8e0150f83de8f7b04d5febc34ec15e","signatures":["SIG_K1_KcZbycCT2k1YX3NwnqTznxCWe7mr6gNXoJMqMapCu3p5DPqqXr7563NBvDb6HKgyGoajMx4zZYFgcnHsyNQqe2YZ8jpyp6"],"compression":"none","packed_context_free_data":"","context_free_data":[],"packed_trx":"22261b5b6200da3412260000000100408c7a02ea3055000000000085269d000859a4abfc2a6e05000100a6823403ea3055000000572d3ccdcd010000000000ea305500000000a8ed3232380000000000ea305580d554cc4b998862df3901000000000004454f5300000000177465737420455243323020446973747269627574696f6e00","transaction":{"expiration":"2018-06-09T00:58:10","ref_block_num":98,"ref_block_prefix":638727386,"max_net_usage_words":0,"max_cpu_usage_ms":0,"delay_sec":0,"context_free_actions":[{"account":"eosio.null","name":"nonce","authorization":[],"data":"59a4abfc2a6e0500"}],"actions":[{"account":"eosio.token","name":"transfer","authorization":[{"actor":"eosio","permission":"active"}],"data":{"from":"eosio","to":"ge4dmmygenes","quantity":"8.0351 EOS","memo":"test ERC20 Distribution"},"hex_data":"0000000000ea305580d554cc4b998862df3901000000000004454f5300000000177465737420455243323020446973747269627574696f6e"}],"transaction_extensions":[]}}},{"status":"executed","cpu_usage_us":7720,"net_usage_words":45,"trx":{"id":"7cc68bd1bc2a41c1fea1d5ad78a829731deb32c2266cac7a48e8089f78cdfe28","signatures":["SIG_K1_Km8DtaKzfGg9AjH2irtEX5g8yg9d3fXifXUXcQsHTutdR6tSfLChKBNmYBT7BuBQvAqYtyoKM4ErQaoTvTpzr2V6jYDv7e"],"compression":"none","packed_context_free_data":"","context_free_data":[],"packed_trx":"86261b5b6200da3412260000000100408c7a02ea3055000000000085269d00088365acfc2a6e0500030000000000ea305500409e9a2264b89a010000000000ea305500000000a8ed3232660000000000ea305580d554cc4c99886201000000010002378c2ee3af80b54738ac8813c80e1ad2689efb06f0bcccd88e83a86f3e84cdcb0100000001000000010002378c2ee3af80b54738ac8813c80e1ad2689efb06f0bcccd88e83a86f3e84cdcb010000000000000000ea305500b0cafe4873bd3e010000000000ea305500000000a8ed3232140000000000ea305580d554cc4c998862002000000000000000ea305500003f2a1ba6a24a010000000000ea305500000000a8ed3232310000000000ea305580d554cc4c998862a44615000000000004454f5300000000a44615000000000004454f53000000000100","transaction":{"expiration":"2018-06-09T00:59:50","ref_block_num":98,"ref_block_prefix":638727386,"max_net_usage_words":0,"max_cpu_usage_ms":0,"delay_sec":0,"context_free_actions":[{"account":"eosio.null","name":"nonce","authorization":[],"data":"8365acfc2a6e0500"}],"actions":[{"account":"eosio","name":"newaccount","authorization":[{"actor":"eosio","permission":"active"}],"data":{"creator":"eosio","name":"ge4dmnagenes","owner":{"threshold":1,"keys":[{"key":"EOS5JxF1JYxuMesBV8Fcvu8TyZzHFsafJAsdHeZMMAZb22wZtDLUL","weight":1}],"accounts":[],"waits":[]},"active":{"threshold":1,"keys":[{"key":"EOS5JxF1JYxuMesBV8Fcvu8TyZzHFsafJAsdHeZMMAZb22wZtDLUL","weight":1}],"accounts":[],"waits":[]}},"hex_data":"0000000000ea305580d554cc4c99886201000000010002378c2ee3af80b54738ac8813c80e1ad2689efb06f0bcccd88e83a86f3e84cdcb0100000001000000010002378c2ee3af80b54738ac8813c80e1ad2689efb06f0bcccd88e83a86f3e84cdcb01000000"},{"account":"eosio","name":"buyrambytes","authorization":[{"actor":"eosio","permission":"active"}],"data":{"payer":"eosio","receiver":"ge4dmnagenes","bytes":8192},"hex_data":"0000000000ea305580d554cc4c99886200200000"},{"account":"eosio","name":"delegatebw","authorization":[{"actor":"eosio","permission":"active"}],"data":{"from":"eosio","receiver":"ge4dmnagenes","stake_net_quantity":"139.4340 EOS","stake_cpu_quantity":"139.4340 EOS","transfer":1},"hex_data":"0000000000ea305580d554cc4c998862a44615000000000004454f5300000000a44615000000000004454f530000000001"}],"transaction_extensions":[]}}},{"status":"executed","cpu_usage_us":1088,"net_usage_words":22,"trx":{"id":"f0f9a1370539ea332ecf715a501f46b177fcfd0dc28de30fbfb0b40f536281b6","signatures":["SIG_K1_JxHSM3sK89xqKmAcEEtQ8CdV5kk1mtfR8PxPq19M2ZhFLwGV7NHZ4Rq5tdr2ykRQSQaeakxRBB4P2vAFwcgCL6NuQxXYhH"],"compression":"none","packed_context_free_data":"","context_free_data":[],"packed_trx":"22261b5b6200da3412260000000100408c7a02ea3055000000000085269d00080b22adfc2a6e05000100a6823403ea3055000000572d3ccdcd010000000000ea305500000000a8ed3232380000000000ea305580d554cc4c998862a08601000000000004454f5300000000177465737420455243323020446973747269627574696f6e00","transaction":{"expiration":"2018-06-09T00:58:10","ref_block_num":98,"ref_block_prefix":638727386,"max_net_usage_words":0,"max_cpu_usage_ms":0,"delay_sec":0,"context_free_actions":[{"account":"eosio.null","name":"nonce","authorization":[],"data":"0b22adfc2a6e0500"}],"actions":[{"account":"eosio.token","name":"transfer","authorization":[{"actor":"eosio","permission":"active"}],"data":{"from":"eosio","to":"ge4dmnagenes","quantity":"10.0000 EOS","memo":"test ERC20 Distribution"},"hex_data":"0000000000ea305580d554cc4c998862a08601000000000004454f5300000000177465737420455243323020446973747269627574696f6e"}],"transaction_extensions":[]}}},{"status":"executed","cpu_usage_us":6118,"net_usage_words":45,"trx":{"id":"c4728e9e494ddb3af6f8f3d67a8048e29aabd5d59618376fbfc22563fb396d24","signatures":["SIG_K1_JuxxAgX7rFpdsZLx1bjQJogzpsQoL1ULwx7ALTi78FxcMhrikjf2uEC8Cz4p1St1zjFQBT6hd8MNo4sywcoYZePdLni1jD"],"compression":"none","packed_context_free_data":"","context_free_data":[],"packed_trx":"86261b5b6200da3412260000000100408c7a02ea3055000000000085269d0008eccbadfc2a6e0500030000000000ea305500409e9a2264b89a010000000000ea305500000000a8ed3232660000000000ea305580d554cc4b9a886201000000010002152920994054380ce13b0503d7b468025448f17da1eec720c6d3c6161d52bf630100000001000000010002152920994054380ce13b0503d7b468025448f17da1eec720c6d3c6161d52bf63010000000000000000ea305500b0cafe4873bd3e010000000000ea305500000000a8ed3232140000000000ea305580d554cc4b9a8862002000000000000000ea305500003f2a1ba6a24a010000000000ea305500000000a8ed3232310000000000ea305580d554cc4b9a886273901b010000000004454f530000000073901b010000000004454f53000000000100","transaction":{"expiration":"2018-06-09T00:59:50","ref_block_num":98,"ref_block_prefix":638727386,"max_net_usage_words":0,"max_cpu_usage_ms":0,"delay_sec":0,"context_free_actions":[{"account":"eosio.null","name":"nonce","authorization":[],"data":"eccbadfc2a6e0500"}],"actions":[{"account":"eosio","name":"newaccount","authorization":[{"actor":"eosio","permission":"active"}],"data":{"creator":"eosio","name":"ge4domygenes","owner":{"threshold":1,"keys":[{"key":"EOS53oserLD4ptmR9wRM7eKjFWT5EQL3pGLVfNf8DwL1ZNYCvLdrD","weight":1}],"accounts":[],"waits":[]},"active":{"threshold":1,"keys":[{"key":"EOS53oserLD4ptmR9wRM7eKjFWT5EQL3pGLVfNf8DwL1ZNYCvLdrD","weight":1}],"accounts":[],"waits":[]}},"hex_data":"0000000000ea305580d554cc4b9a886201000000010002152920994054380ce13b0503d7b468025448f17da1eec720c6d3c6161d52bf630100000001000000010002152920994054380ce13b0503d7b468025448f17da1eec720c6d3c6161d52bf6301000000"},{"account":"eosio","name":"buyrambytes","authorization":[{"actor":"eosio","permission":"active"}],"data":{"payer":"eosio","receiver":"ge4domygenes","bytes":8192},"hex_data":"0000000000ea305580d554cc4b9a886200200000"},{"account":"eosio","name":"delegatebw","authorization":[{"actor":"eosio","permission":"active"}],"data":{"from":"eosio","receiver":"ge4domygenes","stake_net_quantity":"1858.3667 EOS","stake_cpu_quantity":"1858.3667 EOS","transfer":1},"hex_data":"0000000000ea305580d554cc4b9a886273901b010000000004454f530000000073901b010000000004454f530000000001"}],"transaction_extensions":[]}}}],"block_extensions":[],"id":"00000064001897f4e1e46e111681a828975aa5519681d20bfd380decf3135dbf","block_num":100,"ref_block_prefix":292480225}
 */
