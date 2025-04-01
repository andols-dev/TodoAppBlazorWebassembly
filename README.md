# 🚀 **Todo App with Blazor**

## ✨ **Description**
This is a **Todo App** built using **Blazor** and **C#** that allows you to easily create, manage, update, and delete tasks. The app utilizes **Blazored Toast** for real-time notifications and **Bootstrap** for styling, providing a clean and responsive design.

Users can add tasks, mark them as completed, and update them as needed. The app also allows task removal and features an update form for modifying existing tasks.

## 🛠️ **Features**
- ✅ **Add new tasks**: Create new tasks with a name and description.
- ✏️ **Update tasks**: Easily update task details like name and description.
- 🗑️ **Remove tasks**: Delete tasks when they are no longer needed.
- ✅ **Mark tasks as completed**: Tasks can be marked as completed, moving them to the completed section.
- 💬 **Real-time notifications**: Receive notifications on task updates, additions, and deletions using **Blazored Toast**.
- 🖥️ **Responsive design**: The app is fully responsive and looks great on any device.

## 🛠️ **Tech Stack**
- **Blazor**: A framework for building interactive web UIs using C# instead of JavaScript.
- **Blazored.Toast**: A library for displaying toast notifications.
- **Bootstrap**: For a clean, responsive, and modern UI design.
- **C#**: For implementing the business logic and backend functionalities.

## 🔄 **How It Works**
The app uses **Blazor** to handle the front-end interactions. The **TodoTask** service manages the task logic, including adding, updating, removing, and marking tasks as completed. Tasks are stored in a simple **List<Todo>**, and the state is managed by the **TodoTaskService**.

Here are the key components:
- **Add Task**: The user can input the task name and description. Upon submitting, the task is added to the task list.
- **Update Task**: If the user needs to modify a task, an update form is provided to change the name and description of the task.
- **Remove Task**: Tasks can be removed from the list with a single click.
- **Mark as Completed**: A task can be marked as completed and will be moved to the completed tasks section.

Notifications are provided via **Blazored Toast** for actions like task creation, task removal, and task updates, enhancing the user experience.

## 📄 **File Structure**
- `TodoTask.cs`: Contains the logic for managing tasks (add, remove, update, etc.).
- `Todo.cs`: Represents the data model for a Todo task.
- `ITodoTask.cs`: Interface for the `TodoTask` service.
- `Pages/Index.razor`: The main UI page displaying the task management interface.

## 🔧 **Usage**
Upon running the app:
1. **Add a new task** by entering a name and description and clicking "Add Todo".
2. **View active tasks** in the "Active Tasks" section. Each task will have options to:
   - Mark as completed.
   - Update.
   - Remove.
3. **View completed tasks** in the "Completed Tasks" section.






