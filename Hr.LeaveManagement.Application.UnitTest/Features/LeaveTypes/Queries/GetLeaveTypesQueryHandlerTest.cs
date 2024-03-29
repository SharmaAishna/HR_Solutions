﻿using AutoMapper;
using Hr.LeaveManagement.Application.UnitTest.Mocks;
using HrLeaveManagement.Server.Contracts.DataAccess;
using HrLeaveManagement.Server.Features.LeaveTypes.Queries.GetAllLeaveTypes;
using HrLeaveManagement.Server.Logging;
using HrLeaveManagement.Server.MappingProfile;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveManagement.Application.UnitTest.Features.LeaveTypes.Queries
{
    public class GetLeaveTypesQueryHandlerTest
    {
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        private IMapper _mapper;
        private Mock<IAppLogger<GetLeaveTypesQueryHandler>> _mockAppLogger;

        public GetLeaveTypesQueryHandlerTest()
        {
            _mockRepo = MockLeaveTypeRepository.GetMockLeaveTypeRepository();
            
            var mapperConfig=new MapperConfiguration(c =>
            {
                c.AddProfile<LeaveTypeProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _mockAppLogger = new Mock<IAppLogger<GetLeaveTypesQueryHandler>>();
        }

        [Fact]
        public async Task GetLeaveTypeListTest()
        {
            var handler = new GetLeaveTypesQueryHandler(
                _mapper,_mockRepo.Object, _mockAppLogger.Object);
            var result = await handler.Handle(new GetLeaveTypesQuery(),
                CancellationToken.None);
            
            //Assert.NotNull(result);

            result.ShouldBeOfType<List<LeaveTypeDTO>>();
            result.Count.ShouldBe(3);
        }
    }
}
