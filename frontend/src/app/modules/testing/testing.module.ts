import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TestsPageComponent } from './components/tests-page/tests-page.component';
import { TestingRoutingModule } from './testing-routing.module';
import { MaterialModule } from '../shared/material/material.module';
import { TestItemComponent } from './components/test-item/test-item.component';
import { TestListComponent } from './components/test-list/test-list.component';
import { PassTestComponent } from './components/pass-test/pass-test.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    TestsPageComponent,
    TestItemComponent,
    TestListComponent,
    PassTestComponent,
  ],
  imports: [
    CommonModule,
    TestingRoutingModule,
    MaterialModule,
    ReactiveFormsModule,
  ],
})
export class TestingModule {}
