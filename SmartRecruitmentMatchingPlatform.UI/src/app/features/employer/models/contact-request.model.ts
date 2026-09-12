export interface ContactRequestResponse {
  id: number;
  employerName: string;
  message: string;
  status: number;
  createdAt: string;
}

export interface CreateContactRequestRequest {
  jobSeekerProfileId: string;
  message: string | null;
}

export interface UpdateContactRequestStatusRequest {
  status: number;
}