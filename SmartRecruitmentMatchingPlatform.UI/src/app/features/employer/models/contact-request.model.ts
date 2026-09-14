export interface ContactRequestResponse {
  id: number;
  employerName: string;
  message: string;
  status: string;
  createdAt: string;
}

export interface CreateContactRequestRequest {
  jobSeekerProfileId: string;
  message: string;
}

export interface UpdateContactRequestStatusRequest {
  status: string;
}