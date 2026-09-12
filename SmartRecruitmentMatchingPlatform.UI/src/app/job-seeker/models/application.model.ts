export interface Application {
  id: number;
  jobSeekerProfileId: string;
  vacancyId: number;
  status: string;
  matchScore: number | null;
  appliedAt: string;
  updatedAt: string;
}