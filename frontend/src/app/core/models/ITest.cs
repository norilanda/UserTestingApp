export interface ITest
{
  id: number;
  name: string;
  tasks: Task[];
}

interface Task
{
  id: number;
  number: number;
  question: string;
}
