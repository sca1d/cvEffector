#include "..\include\ColorPicker.h"

DLL_EXPORT int test(void) {

	if (glfwInit() == GL_FALSE) return -1;

	GLFWwindow* window = glfwCreateWindow(640, 480, "OpenGL Simple", NULL, NULL);
	if (!window) {
		glfwTerminate();
		return -1;
	}

	glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 2);
	glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 1);

	glfwMakeContextCurrent(window);
	glfwSwapInterval(0);

	if (glewInit() != GLEW_OK) return -1;

    // �t���[�����[�v
    while (glfwWindowShouldClose(window) == GL_FALSE)
    {
        // �o�b�t�@�̃N���A
        glClearColor(0.2f, 0.2f, 0.2f, 0.0f);
        glClear(GL_COLOR_BUFFER_BIT);

        // �F�w��
        glColor4f(1.0, 0.0, 0.0, 1.0);

        // 3�̒��_���W��GPU�ɓ]��
        glBegin(GL_TRIANGLES);
        glVertex2f(0, 0.5);
        glVertex2f(-0.5, -0.5);
        glVertex2f(0.5, -0.5);
        glEnd();

        // �_�u���o�b�t�@�̃X���b�v
        glfwSwapBuffers(window);
        glfwPollEvents();
    }

    // GLFW�̏I������
    glfwTerminate();

    return 0;

}
