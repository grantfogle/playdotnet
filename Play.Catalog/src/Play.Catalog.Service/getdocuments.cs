// get documenttests.cs
[TestCase(TransactionDataType.Request)]
    [TestCase(TransactionDataType.Response)]
    [TestCase(TransactionDataType.RecondoAccountStatusRequest)]
    public async Task GetSalucroRequestResponseGetResponsesTest_EndpointSucceeds(TransactionDataType transactionDataType)
    {
        var testId = new Guid("5aa5850e-1b2c-4827-a56c-af9c01673675");
        _testClient = IntegrationTestContext.TestServer.CreateClient();
        var querySession = IntegrationTestContext.Store.QuerySession();
        var account = await querySession.Query<AccountDto>().Where(x => x.Id == testId)
            .FirstAsync();

        var requestOptions = new RequestResponseOptions
        {
            TransactionDataType = transactionDataType,
            AccountNumber = account.Registration.AccountNumber,
            ClientName = account.Organization.Name
        };

        _httpRequest = new HttpRequestMessage(HttpMethod.Get, "RequestResponse/GetSalucro" + requestOptions.ToQueryString());

        var httpResponse = await _testClient.SendAsync(_httpRequest);

        if (transactionDataType != TransactionDataType.Response && transactionDataType != TransactionDataType.Request)
        {
            httpResponse.ShouldNotBeNull();
            httpResponse.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }
        else
        {
            await httpResponse.ShouldBeSuccessAsync();
        }
    }


// initialtestdata.cs
session.Store(new Estimation.Data.TestData().GetPaymentAutoLoginSubmissionsData.ToArray());
        session.Store(new Estimation.Data.TestData().GetPaymentVendorResponseLogsData.ToArray());

//estimation/data/testdata
public List<PaymentAutoLoginSubmission> GetPaymentAutoLoginSubmissionsData =>
        new()
        {
            new PaymentAutoLoginSubmission
            {
                AccountId = new Guid("5aa5850e-1b2c-4827-a56c-af9c01673675"),
                AccountNumber = "test32132465",
                Organization = "optum.dignity.mercybakersfield",
                DateAddUtc = new DateTime(1624990140000),
                RequestTimeUtc = DateTime.Now,
            },
            new PaymentAutoLoginSubmission
            {
                AccountId = new Guid("5aa5850e-1b2c-4827-a56c-af9c01673675"),
                AccountNumber = "test32132465",
                Organization = "optum.dignity.mercybakersfield",
                DateAddUtc = new DateTime(1624980140000),
                RequestTimeUtc = DateTime.Now,
            }
        };

    public List<PaymentVendorResponseLog> GetPaymentVendorResponseLogsData =>
        new()
        {
            new PaymentVendorResponseLog
            {
                Id = new Guid("F80C6398-3C59-42B9-80E5-AC158B795125"),
                AccountId = "4F0AA27A-3686-4A65-B82B-945584F5E8C6",
                VendorTimestamp = new DateTime(1624980140000),
                DateAddUtc = new DateTime(1624980140000),
                EncounterBalanceAccountNumber = "test32132465",
                UserName = "loginA"
            },
            new PaymentVendorResponseLog
            {
                Id = new Guid("4FC98782-1A9F-49F6-A862-C45B4FE6944D"),
                AccountId = "B9909015-4702-4F50-980E-3E7FF505DB61",
                VendorTimestamp = new DateTime(1624970140000),
                DateAddUtc = new DateTime(1624970140000),
                EncounterBalanceAccountNumber = "test32132465",
                UserName = "loginB"
            }
        };

// payments/testdata/testdata

new CollectPaymentSubmission
            {
                Id = new Guid("1024955E-212C-4A38-9D0C-94DA35F1C10C"),
                AccountId = new Guid("4F0AA27A-3686-4A65-B82B-945584F5E8C6"),
                AccountNumber = "test32132465",
                Organization = "optum.dignity.mercybakersfield",
                UserLogin = "loginA"
            },
            new CollectPaymentSubmission
            {
                Id = new Guid("414CBD40-F788-4188-829A-7C6838E5AFBC"),
                AccountId = new Guid("B9909015-4702-4F50-980E-3E7FF505DB61"),
                AccountNumber = "test32132465",
                Organization = "optum.dignity.mercybakersfield",
                UserLogin = "loginB"
            }