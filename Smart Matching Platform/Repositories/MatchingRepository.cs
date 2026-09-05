//using microsoft.entityframeworkcore;
//using smartrecruitmentmatchingplatform.api.data;
//using smartrecruitmentmatchingplatform.api.models.entities;

//namespace smartrecruitmentmatchingplatform.api.repositories;

//public class matchingrepository : imatchingrepository
//{
//    private readonly applicationdbcontext _context;

//    public matchingrepository(applicationdbcontext context)
//    {
//        _context = context;
//    }

//    public async task<jobseekerprofile?> getjobseekerasync(guid userid)
//    {
//        return await _context.jobseekerprofiles
//            .include(x => x.skills)
//            .firstordefaultasync(x => x.userid == userid);
//    }

//    public async task<list<vacancy>> getallvacanciesasync()
//    {
//        return await _context.vacancies
//            .include(x => x.requiredskills)
//            .include(x => x.employer)
//            .tolistasync();
//    }
//}