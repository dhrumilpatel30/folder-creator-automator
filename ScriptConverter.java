import java.io.*;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Scanner;

public class ScriptConverter {

    private static final String SCRIPT_DIR = System.getProperty("user.dir");
    private static final String CONFIG_FILE = SCRIPT_DIR + File.separator + "FileMapping.conf";
    private static final String TEMPLATES_DIR = SCRIPT_DIR + File.separator + "Files";
    private static final String DESTINATION_DIR = SCRIPT_DIR;
    private static final String LOG_FILE = SCRIPT_DIR + File.separator + "script_log.txt";

    public static void main(String[] args) {
        if (args.length != 2) {
            System.out.println("Usage: java ScriptConverter <arg1> <arg2>");
            System.exit(1);
        }

        String arg1 = args[0];
        String arg2 = args[1];

        try {
            // Create log file if it doesn't exist
            createFileIfNotExists(LOG_FILE);

            // Check if the configuration file exists
            File configFile = new File(CONFIG_FILE);
            if (!configFile.exists()) {
                System.err.println("Error: Configuration file not found.");
                System.exit(1);
            }

            Scanner scanner = new Scanner(configFile);

            while (scanner.hasNextLine()) {
                String line = scanner.nextLine();
                String[] parts = line.split(":");
                if (parts.length != 2) continue;

                String pattern = parts[0];
                String folder = parts[1];

                String fileName = pattern.replace("{{ARG1}}", arg1).replace("{{ARG2}}", arg2);
                String destFolder = folder.replace("{{ARG1}}", arg1).replace("{{ARG2}}", arg2);
                String templateFile = TEMPLATES_DIR + File.separator + pattern;
                String fullPath = DESTINATION_DIR + File.separator + destFolder + File.separator + fileName;

                // Create directories if they don't exist
                createDirectories(fullPath);

                // Check if the file already exists
                File fullPathFile = new File(fullPath);
                if (fullPathFile.exists()) {
                    logMessage("File already exists at " + fullPath);
                } else {
                    // Create the file based on the template
                    createFileFromTemplate(templateFile, fullPath, arg1, arg2);
                    logMessage("File created successfully at " + fullPath);
                }
            }

            scanner.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    private static void createFileIfNotExists(String filePath) throws IOException {
        File file = new File(filePath);
        if (!file.exists()) {
            file.createNewFile();
        }
    }

    private static void createDirectories(String filePath) throws IOException {
        File directory = new File(filePath).getParentFile();
        if (!directory.exists()) {
            directory.mkdirs();
        }
    }

    private static void createFileFromTemplate(String templateFile, String destFile, String arg1, String arg2) throws IOException {
        BufferedReader reader = new BufferedReader(new FileReader(templateFile));
        BufferedWriter writer = new BufferedWriter(new FileWriter(destFile));

        String line;
        while ((line = reader.readLine()) != null) {
            line = line.replace("{{ARG1}}", arg1).replace("{{ARG2}}", arg2);
            writer.write(line);
            writer.newLine();
        }

        reader.close();
        writer.close();
    }

    private static void logMessage(String message) throws IOException {
        BufferedWriter writer = new BufferedWriter(new FileWriter(LOG_FILE, true));
        String timestamp = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss").format(new Date());
        writer.write(timestamp + " - " + message);
        writer.newLine();
        writer.close();
    }
}
