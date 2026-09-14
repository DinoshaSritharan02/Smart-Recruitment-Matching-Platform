export interface Application {

  id: number;

  vacancyId: number;

  jobTitle: string;

  companyName: string;

  location: string;

  status: string;

  matchScore: number | null;

  appliedAt: string;

  updatedAt: string;

}