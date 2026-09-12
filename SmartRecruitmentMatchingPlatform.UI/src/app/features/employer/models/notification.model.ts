export interface NotificationResponse {
  id: number;
  title: string;
  message: string;
  isRead: boolean;
  createdAt: string;
}

export interface CreateNotificationRequest {
  userId: string;
  title: string;
  message: string;
}