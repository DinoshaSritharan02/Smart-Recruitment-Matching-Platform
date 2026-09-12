export interface MatchRequest {
  jobSeekerId: string;
}

export interface MatchResult {
  vacancyId: number;
  jobTitle: string;
  companyName: string;
  matchPercentage: number;
  skillScore: number;
  experienceScore: number;
  educationScore: number;
  locationScore: number;
  matchingSkills: string[];
  missingSkills: string[];
}