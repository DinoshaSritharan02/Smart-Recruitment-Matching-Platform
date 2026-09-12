export interface ApplicationResponse {
  id: number;
  jobSeekerProfileId: string;
  vacancyId: number;
  status: number;
  matchScore: number | null;
  appliedAt: string;
  updatedAt: string;
}

export interface RankedApplicantResponse {
  applicationId: number;
  jobSeekerProfileId: string;
  candidateName: string;
  matchScore: number | null;
  missingSkills: string[];
  status: string;
  appliedAt: string;
}

export interface UpdateApplicationStatusRequest {
  status: number;
}