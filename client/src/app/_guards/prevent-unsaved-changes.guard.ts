import { CanDeactivateFn } from '@angular/router';
import { MemberEditComponent } from '../members/member-edit/member-edit.component';
import { inject } from '@angular/core';
import { ConfirmDialogComponent } from '../modals/confirm-dialog/confirm-dialog.component';
import { ConfirmService } from '../_services/confirm.service';

export const preventUnsavedChangesGuard: CanDeactivateFn<MemberEditComponent> = (component) => {
  const confirmService = inject(ConfirmService);
  
  if(component.editForm?.dirty){
    return confirmService.confirm() ?? false;
  }
  return true;
};
