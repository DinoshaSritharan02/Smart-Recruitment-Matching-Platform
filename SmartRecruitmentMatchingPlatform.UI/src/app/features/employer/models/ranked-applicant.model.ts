export interface RankedApplicant {
  applicationId: number;
  applicantId: number;
  fullName: string;
  email: string;
  matchScore: number;
  status: string;
}